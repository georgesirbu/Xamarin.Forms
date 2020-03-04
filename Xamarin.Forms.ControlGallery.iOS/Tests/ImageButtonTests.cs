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
		public void ImageButtonAspect()
		{
			StackLayout stackLayout = new StackLayout();
			string imageSource = "coffee.png";

			ImageButton imageButtonFill = new ImageButton()
			{
				Source = imageSource,
				Aspect = Aspect.Fill,
				AutomationId = "TestImage"
			};

			stackLayout.Children.Add(imageButtonFill);

			ContentPage contentPage = new ContentPage()
			{
				Content = stackLayout
			};

			using(var pageRenderer = GetRenderer(contentPage))
			{
				var nativeControl = GetNativeControl(imageButtonFill);
				contentPage.Layout(new Rectangle(0, 0, 1200, 1200));

				var image = nativeControl.ImageView.Image;

				imageButtonFill.SizeChanged += (_, __) =>
				{
					image = nativeControl.ImageView.Image;
				};

				/*await Task.Run(async () =>
					{
						while(true)
							await Task.Delay(5000);
					})
					.ConfigureAwait(false);*/
			}

			//return true;
		}
	}
}