using System;
using Microsoft.Xna.Framework.Media;

namespace SexyFramework
{
	public class SoundEffectWrapper
	{
		public SoundEffectWrapper(Song s)
		{
			this.load(s);
		}

		public void load(Song s)
		{
			this.m_Song = s;
		}

		public bool isPlaying()
		{
			return this.m_isPlaying;
		}

		public void play()
		{
			// iOS: MediaPlayer not available, no-op for now
			this.m_isPlaying = true;
		}

		public void stop()
		{
			this.m_isPlaying = false;
		}

		public void setLoop(bool isLooped)
		{
		}

		public void setVolume(float volume)
		{
		}

		public Song m_Song;

		public double mVolume;

		public double mVolumeAdd;

		public double mVolumeCap = 1.0;

		public bool mStopOnFade;

		public bool m_isPlaying;
	}
}
