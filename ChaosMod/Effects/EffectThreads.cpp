#include <stdafx.h>

#include "EffectThreads.h"

#include "Util/Script.h"

static std::unordered_map<LPVOID, std::unique_ptr<EffectThread>> m_Threads;

static auto _StopThreadImmediately(auto it)
{
	auto &[threadId, thread] = *it;

	// Give thread a chance to stop gracefully
	// OK so maybe not really immediately but it's still blocking
	thread->Stop();
	int count = 0;
	while (!thread->HasStopped() && count++ < 20)
	{
		SwitchToFiber(g_MainThread);
		thread->OnRun();
	}

	return m_Threads.erase(it);
}

namespace EffectThreads
{
	LPVOID CreateThread(RegisteredEffect *pEffect, bool bIsTimed)
	{
		auto thread         = std::make_unique<EffectThread>(pEffect, bIsTimed);
		auto threadId       = thread->m_Thread;
		m_Threads[threadId] = std::move(thread);

		return threadId;
	}

	void StopThread(LPVOID threadId)
	{
		if (m_Threads.contains(threadId))
		{
			m_Threads.at(threadId)->Stop();
		}
	}

	void StopThreadImmediately(LPVOID threadId)
	{
		if (m_Threads.contains(threadId))
		{
			_StopThreadImmediately(m_Threads.find(threadId));
		}
	}

	void StopThreads()
	{
		for (auto &[threadId, thread] : m_Threads)
		{
			thread->Stop();
		}
	}

	void StopThreadsImmediately()
	{
		for (auto it = m_Threads.begin(); it != m_Threads.end();)
		{
			it = _StopThreadImmediately(it);
		}
	}

	void PauseThisThread(DWORD ulTimeMs)
	{
		auto fiber = GetCurrentFiber();
		if (m_Threads.contains(fiber))
		{
			m_Threads.at(fiber)->m_PauseTimestamp = GetTickCount64() + ulTimeMs;
		}
	}

	bool IsThreadPaused(LPVOID threadId)
	{
		if (!m_Threads.contains(threadId))
		{
			return true;
		}

		return m_Threads.at(threadId)->m_PauseTimestamp >= GetTickCount64();
	}

	void _RunThread(auto &it, DWORD64 curTimestamp)
	{
		auto &[threadId, thread] = *it;

		if (thread->HasStopped())
		{
			it = m_Threads.erase(it);
			return;
		}

		if (GetTickCount64() > thread->m_PauseTimestamp)
		{
			thread->OnRun();
		}

		it++;
	}

	void RunThreads()
	{
		auto curTimestamp = GetTickCount64();
		for (auto it = m_Threads.begin(); it != m_Threads.end();)
		{
			_RunThread(it, curTimestamp);
		}
	}

	void RunThread(LPVOID threadId)
	{
		auto result = m_Threads.find(threadId);
		if (result != m_Threads.end())
		{
			_RunThread(result, GetTickCount64());
		}
	}

	bool DoesThreadExist(LPVOID threadId)
	{
		return m_Threads.contains(threadId);
	}

	bool HasThreadOnStartExecuted(LPVOID threadId)
	{
		if (!m_Threads.contains(threadId))
		{
			return true;
		}

		return m_Threads.at(threadId)->HasOnStartExecuted();
	}
}