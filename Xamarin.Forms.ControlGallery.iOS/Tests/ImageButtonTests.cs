using System.Collections;
using NUnit.Framework;

namespace Xamarin.Forms.ControlGallery.iOS.Tests
{
	public class ImageButtonTests : PlatformTestFixture
	{

		[Test, Category("IsVisible")]
		[Description("VisualElement visibility should match renderer visibility")]
		public void ImageButtonAspect()
		{
			var imageButtonAspectFill = new ImageButton() { Source =  "coffee.png", Aspect = Aspect.AspectFill };
			var imageButtonAspectFit = new ImageButton() { Source = "coffee.png", Aspect = Aspect.AspectFit };
			var imageButtonFill = new ImageButton() { Source = "coffee.png", Aspect = Aspect.Fill };

			using (var imageButtonAspectFillRenderer = GetRenderer(imageButtonAspectFill))
			using (var imageButtonAspectFitRenderer = GetRenderer(imageButtonAspectFit))
			using (var imageButtonFillRenderer = GetRenderer(imageButtonFill))
			{
				imageButtonAspectFill.Layout(new Rectangle(0, 0, 200, 200));
			}
		}
	}
}