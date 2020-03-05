using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using UIKit;

namespace Xamarin.Forms.ControlGallery.iOS.Tests
{
	public class ImageButtonTests : PlatformTestFixture
	{

		[Test(), Category("ImageButton")]
		[Description("ImageButton Aspects")]
		public async Task ImageButtonAspect()
		{
			StackLayout stackLayout = new StackLayout();
			string imageSource = "coffee.png";

			ImageButton imageButtonFill = new ImageButton()
			{
				Source = imageSource,
				Aspect = Aspect.Fill,
				AutomationId = "TestImage"
			};


			ImageButton imageButtonurl = new ImageButton()
			{
				Source = new UriImageSource()
				{
					Uri = new Uri("https://upload.wikimedia.org/wikipedia/commons/3/3d/LARGE_elevation.jpg"),
					CachingEnabled = false
				}
			};

			//stackLayout.Children.Add(imageButtonFill);
			stackLayout.Children.Add(imageButtonurl);

			ContentPage contentPage = new ContentPage()
			{
				Content = stackLayout
			};

			await Device.InvokeOnMainThreadAsync(async () =>
			{
				using (var pageRenderer = GetRenderer(contentPage))
				{
					contentPage.Layout(new Rectangle(0, 0, 1200, 1200));

					// if I use a local image the image actually does load but I fear that this
					// is just luck and at some point it might randomly break
					var image = GetNativeControl(imageButtonFill).ImageView.Image;

					// to illustrate async loading I added this image which uses a url
					// which will be delayed with loading. Here you'll notice this is null
					// I had to turn caching off because with caching enabled it shows up the second time you try
					var control = GetNativeControl(imageButtonurl);
					var imageUrl = control.ImageView.Image;

					while (imageUrl == null)
					{
						await Task.Delay(2000);
						imageUrl = control.ImageView.Image;
					}
				}

			})
			.ConfigureAwait(false);

			Assert.Pass();
		}
	}
}