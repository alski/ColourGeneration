using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should;
using System.Windows.Media;
using ColourGeneration;

namespace ColorGenerationTests
{
    [TestFixture]
    public class ThatColourGenerator
    {
     
        [Test]
        public void ShouldBeFullRedAndRampGreenFrom0To255()
        {
            var rampUp = Enumerable.Range(0, 255);
            var colours = from x in rampUp let y = ColorGenerator.FromIndex(x) let z = (byte)(x) select new { y, z };
            colours.All(result => result.y.R == 255).ShouldBeTrue();
            colours.All(result => result.y.G == result.z).ShouldBeTrue();
            colours.All(result => result.y.B == 0).ShouldBeTrue();
        }

        [Test]
        public void ShouldBeFullGreenAndRampDownRedFrom256To511()
        {
            var rampUp = Enumerable.Range(0, 255);
            var colours = from x in rampUp let y = ColorGenerator.FromIndex(x + 256) let z = (byte)(255 - x) select new { y, z };
            colours.All(result => result.y.R == result.z).ShouldBeTrue();
            colours.All(result => result.y.G == 255).ShouldBeTrue();
            colours.All(result => result.y.B == 0).ShouldBeTrue();
        }

        [Test]
        public void ShouldBeFullGreenAndRampUpBlueFrom512To767()
        {
            var rampUp = Enumerable.Range(0, 255);
            var colours = from x in rampUp let y = ColorGenerator.FromIndex(x + 512) let z = (byte)(x) select new { y, z };
            colours.All(result => result.y.R == 0).ShouldBeTrue();
            colours.All(result => result.y.G == 255).ShouldBeTrue();
            colours.All(result => result.y.B == result.z).ShouldBeTrue();
        }

        [Test]
        public void ShouldBeFullBlueAndRampDownGreenFrom768To1023()
        {
            var rampUp = Enumerable.Range(0, 255);
            var colours = from x in rampUp let y = ColorGenerator.FromIndex(x + 768) let z = (byte)(255 - x) select new { y, z };
            colours.All(result => result.y.R == 0).ShouldBeTrue();
            colours.All(result => result.y.G == result.z).ShouldBeTrue();
            colours.All(result => result.y.B == 255).ShouldBeTrue();
        }

        [Test]
        public void ShouldBeFullBlueAndRampUpRedFrom1024To1279()
        {
            var rampUp = Enumerable.Range(0, 255);
            var colours = from x in rampUp let y = ColorGenerator.FromIndex(x + 1024) let z = (byte)(x) select new { y, z };
            colours.All(result => result.y.R == result.z).ShouldBeTrue();
            colours.All(result => result.y.G == 0).ShouldBeTrue();
            colours.All(result => result.y.B == 255).ShouldBeTrue();
        }

        [Test]
        public void ShouldBeFullRedAndRampDownBlueFrom1280To1535()
        {
            var rampUp = Enumerable.Range(0, 255);
            var colours = from x in rampUp let y = ColorGenerator.FromIndex(x + 1280) let z = (byte)(255 - x) select new { y, z };
            colours.All(result => result.y.R == 255).ShouldBeTrue();
            colours.All(result => result.y.G == 0).ShouldBeTrue();
            colours.All(result => result.y.B == result.z).ShouldBeTrue();
        }


    }
}
