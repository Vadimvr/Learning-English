using NUnit.Framework;

namespace test2
{
    public class PathToMultimediaTest
    {
        [TestFixture]
        public class PathToMultimedia_Test
        {
            
            private readonly string id = "001";
            private readonly string path = @"D:\a\a";
            [SetUp]
            public void SetUp()
            {
              
            }

            [Test]
            public void PathToMultimedia_Test_PathSong()
            {
               
                Assert.IsTrue(new LElWPF.Core.Models.PathToMultimedia(id, path).PathSong == path + @"\song\" + id + ".mp3",
                $"{new LElWPF.Core.Models.PathToMultimedia(id, path).PathSong}!=\n  {path}\\song\\{id}.mp3");
            }
            [Test]
            public void PathToMultimedia_Test_PathImg()
            {
                
                Assert.IsTrue(new LElWPF.Core.Models.PathToMultimedia(id, path).PathImg == path + @"\img\" + id + ".jpg",
                   $"{new LElWPF.Core.Models.PathToMultimedia(id, path).PathImg} == {path} + \\img\\ + {id} + .jpg");
            }
          
        }
    }
}