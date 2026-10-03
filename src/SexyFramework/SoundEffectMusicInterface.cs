using System;
using Microsoft.Xna.Framework.Content;

namespace SexyFramework
{
	// iOS stub: MediaPlayer not available, all methods are no-ops
	public class SoundEffectMusicInterface : MusicInterface
	{
		public SoundEffectMusicInterface()
		{
		}

		public override bool isPlayingUserMusic()
		{
			return false;
		}

		public override void stopUserMusic()
		{
		}
	}
}
