using System.Threading.Tasks;
using uas_apk.Data;
namespace uas_apk
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            _ = InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            await UserRepository.LoadUsersAsync();
            await NoteRepository.LoadNotesAsync();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}