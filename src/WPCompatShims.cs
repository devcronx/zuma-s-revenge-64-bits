// Compatibility shims for Windows Phone / XNA APIs not present in MonoGame.
// These provide no-op or simplified implementations for iOS.

using System;
using Microsoft.Xna.Framework;

namespace Microsoft.Phone.Shell
{
    public class DeactivatedEventArgs : EventArgs { }
    public class ActivatedEventArgs : EventArgs { }

    // Minimal stand-in for PhoneApplicationService. The GameMain wires
    // MonoGame's Activated/Deactivated events to these.
    public class PhoneApplicationService
    {
        private static readonly PhoneApplicationService _current = new PhoneApplicationService();
        public static PhoneApplicationService Current => _current;

        public event EventHandler<DeactivatedEventArgs> Deactivated;
        public event EventHandler<ActivatedEventArgs> Activated;

        public void RaiseDeactivated() => Deactivated?.Invoke(this, new DeactivatedEventArgs());
        public void RaiseActivated() => Activated?.Invoke(this, new ActivatedEventArgs());
    }
}

namespace Microsoft.Phone.Tasks
{
    // Opens a URL — on iOS this is a no-op for now (could launch browser via Xamarin.Essentials later).
    public class WebBrowserTask
    {
        public Uri URL { get; set; }
        public System.Uri Uri { get; set; }
        public void Show() { /* no-op on iOS */ }
    }

    public class MarketplaceDetailTask
    {
        public string ContentIdentifier { get; set; }
        public int ContentType { get; set; }
        public void Show() { /* no-op on iOS */ }
    }
}

namespace Microsoft.Xna.Framework.GamerServices
{
    public class SignedInEventArgs : EventArgs
    {
        public SignedInGamer Gamer => new SignedInGamer();
    }

    // Stub GameComponent — MonoGame has no GamerServices; trial mode is always off.
    public class GamerServicesComponent : GameComponent
    {
        public GamerServicesComponent(Game game) : base(game) { }
    }

    public static class Guide
    {
        // Sideloaded personal build = full version, never trial.
        public static bool IsTrialMode => false;
        public static bool SimulateTrialMode { get; set; }
        public static bool IsVisible => false;

        public static void ShowMarketplace(int playerIndex) { /* no-op */ }

        public static IAsyncResult BeginShowMessageBox(string title, string text,
            System.Collections.Generic.IEnumerable<string> buttons, int focusButton,
            Microsoft.Xna.Framework.GamerServices.MessageBoxIcon icon,
            AsyncCallback callback, object state)
        {
            // No message box on iOS; invoke callback with "no button" result.
            var result = new MessageBoxResult(state);
            callback?.Invoke(result);
            return result;
        }

        public static int? EndShowMessageBox(IAsyncResult result) => null;

        private class MessageBoxResult : IAsyncResult
        {
            public MessageBoxResult(object state) { AsyncState = state; }
            public object AsyncState { get; }
            public System.Threading.WaitHandle AsyncWaitHandle => null;
            public bool CompletedSynchronously => true;
            public bool IsCompleted => true;
        }
    }

    public enum MessageBoxIcon
    {
        None = 0,
        Error = 1,
        Warning = 2,
        Alert = 3,
    }

    public static class Gamer
    {
        private static readonly SignedInGamer[] _signedInGamers = new SignedInGamer[] { new SignedInGamer() };
        public static System.Collections.ObjectModel.ReadOnlyCollection<SignedInGamer> SignedInGamers =>
            new System.Collections.ObjectModel.ReadOnlyCollection<SignedInGamer>(_signedInGamers);
    }

    // Additional GamerServices stubs (not in MonoGame)
    public class SignedInGamer
    {
        public bool IsSignedInToLive => false;
        public string Gamertag => "";
        public static event EventHandler<SignedInEventArgs> SignedIn;
        public GamerProfile GetProfile() => new GamerProfile();
        public IAsyncResult BeginGetProfile(AsyncCallback callback, object state)
        {
            var result = new SimpleAsyncResult(state);
            callback?.Invoke(result);
            return result;
        }
        public GamerProfile EndGetProfile(IAsyncResult result) => new GamerProfile();
        public IAsyncResult BeginAwardAchievement(string achievementKey, AsyncCallback callback, object state)
        {
            var result = new SimpleAsyncResult(state);
            callback?.Invoke(result);
            return result;
        }
        public void EndAwardAchievement(IAsyncResult result) { }
        public IAsyncResult BeginGetAchievements(AsyncCallback callback, object state)
        {
            var result = new SimpleAsyncResult(state);
            callback?.Invoke(result);
            return result;
        }
        public AchievementCollection EndGetAchievements(IAsyncResult result) => new AchievementCollection();
        public LeaderboardWriter LeaderboardWriter => new LeaderboardWriter();
    }


    public class GamerProfile : System.IDisposable
    {
        public void Dispose() { }
        public System.IO.Stream GetGamerPicture() => new System.IO.MemoryStream();
    }

    public class SimpleAsyncResult : IAsyncResult
    {
        public SimpleAsyncResult(object state) { AsyncState = state; }
        public object AsyncState { get; }
        public System.Threading.WaitHandle AsyncWaitHandle => null;
        public bool CompletedSynchronously => true;
        public bool IsCompleted => true;
    }



    public class Achievement
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GamerScore { get; set; }
        public bool Earned { get; set; }
        public bool IsEarned => Earned;
    }

    public class AchievementCollection : System.Collections.ObjectModel.Collection<Achievement> { }

    public class GameUpdateRequiredException : Exception
    {
        public GameUpdateRequiredException() { }
        public GameUpdateRequiredException(string message) : base(message) { }
    }

    public class LeaderboardReader
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<LeaderboardEntry> Entries =>
            new System.Collections.ObjectModel.ReadOnlyCollection<LeaderboardEntry>(
                new System.Collections.Generic.List<LeaderboardEntry>());
        public bool CanPageUp => false;
        public bool CanPageDown => false;
        public int PageStart => 0;
        public static IAsyncResult BeginRead(LeaderboardIdentity identity, int pageStart, int pageSize,
            AsyncCallback callback, object state)
        {
            var result = new SimpleAsyncResult(state);
            callback?.Invoke(result);
            return result;
        }
        public static LeaderboardReader EndRead(IAsyncResult result) => new LeaderboardReader();
        public IAsyncResult BeginPageUp(AsyncCallback callback, object state)
        {
            var result = new SimpleAsyncResult(state);
            callback?.Invoke(result);
            return result;
        }
        public IAsyncResult BeginPageDown(AsyncCallback callback, object state)
        {
            var result = new SimpleAsyncResult(state);
            callback?.Invoke(result);
            return result;
        }
        public void EndPageUp(IAsyncResult result) { }
        public void EndPageDown(IAsyncResult result) { }
    }

    public class LeaderboardEntry
    {
        public string Gamertag => "";
        public long Rating { get; set; }
        public SignedInGamer Gamer => null;
        public System.Collections.ObjectModel.ReadOnlyCollection<LeaderboardColumn> Columns =>
            new System.Collections.ObjectModel.ReadOnlyCollection<LeaderboardColumn>(
                new System.Collections.Generic.List<LeaderboardColumn>());
    }

    public class LeaderboardColumn
    {
        public string DisplayName => "";
        public long Value => 0;
    }

    public static class LeaderboardExtensions
    {
        public static int GetValueInt32(this System.Collections.ObjectModel.ReadOnlyCollection<LeaderboardColumn> columns, string columnName)
        {
            return 0; // Stub - leaderboards not supported on iOS
        }
    }

    public class LeaderboardWriter
    {
        public IAsyncResult BeginWriteLeaderboard(LeaderboardIdentity identity,
            System.Collections.Generic.Dictionary<string, long> values,
            AsyncCallback callback, object state)
        {
            var result = new SimpleAsyncResult(state);
            callback?.Invoke(result);
            return result;
        }
        public void EndWriteLeaderboard(IAsyncResult result) { }
        public LeaderboardReader GetLeaderboard(LeaderboardIdentity identity) => new LeaderboardReader();
        public IAsyncResult BeginGetLeaderboard(LeaderboardIdentity identity,
            AsyncCallback callback, object state)
        {
            var result = new SimpleAsyncResult(state);
            callback?.Invoke(result);
            return result;
        }
        public LeaderboardReader EndGetLeaderboard(IAsyncResult result) => new LeaderboardReader();
    }

    public class LeaderboardIdentity
    {
        public int GameId { get; set; }
        public static LeaderboardIdentity Create(LeaderboardKey key, int gameId)
        {
            return new LeaderboardIdentity { GameId = gameId };
        }
    }

    public enum LeaderboardKey
    {
        BestScoreLife,
        BestScoreTime,
    }
}
