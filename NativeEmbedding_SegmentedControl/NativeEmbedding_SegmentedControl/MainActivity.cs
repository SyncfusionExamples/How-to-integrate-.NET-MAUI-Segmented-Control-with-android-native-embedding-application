using Microsoft.Maui.Embedding;
using Android.App;
using Android.OS;
using Syncfusion.Maui.Buttons;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Core.Hosting;

namespace NativeEmbedding_SegmentedControl
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        MauiContext? _mauiContext;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
            builder.ConfigureSyncfusionCore();
            MauiApp mauiApp = builder.Build();
            _mauiContext = new MauiContext(mauiApp.Services, this);

            SfSegmentedControl segmentedControl = new SfSegmentedControl();
            List<SfSegmentItem> itemList = new List<SfSegmentItem>
            {
                new SfSegmentItem() {Text = "Day"},
                new SfSegmentItem() {Text = "Week"},
                new SfSegmentItem() {Text = "Month"},
                new SfSegmentItem() {Text = "Year"},
            };
            segmentedControl.ItemsSource = itemList;
            Android.Views.View view = segmentedControl.ToPlatform(_mauiContext);

            // Set our view from the "main" layout resource
            SetContentView(view);
        }
    }
}