using NUnit.Framework;
using LElWPF.Core;

namespace Tests
{
    public class Tests2
    {
        [TestFixture]
        public class PathToMultimedia_Test
        {
            private LElWPF.Core.Models.PathToMultimedia _PathToMultimedia;
            private string id = "001";
            private string path = @"D:\a\a";
            [SetUp]
            public void SetUp()
            {
                _PathToMultimedia = new LElWPF.Core.Models.PathToMultimedia(id, path);
            }

            [Test]
            public void PathImg()
            {
                var result = _PathToMultimedia.PathImg;
                var result2 = path + @"\img\" + id + ".jpg";
                Assert.IsFalse(result == result2, $"{result } != {result2}");
            }
            [Test]
            public void PathSong()
            {
                var result = _PathToMultimedia.PathSong;
                var result2 = path + @"\song\" + id + ".mp3";
                var res = result == result2;
                var s = $"{result } != {result2}";
                Assert.IsFalse(true, s);
            }
            //PathImg = path + @"\img\" + id + ".jpg";
            //PathSong = path + @"\song\" + id + ".mp3";
        }
    }
}