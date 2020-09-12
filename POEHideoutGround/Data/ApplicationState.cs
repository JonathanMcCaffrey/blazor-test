namespace POEHideoutGround.Data
{
    public class ApplicationState
    {
        public bool IsDarkTheme { get; set; }

        public void ToggleTheme()
        {
            IsDarkTheme = !IsDarkTheme;
            NotifyStateChanged();
        }

        public event System.Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
