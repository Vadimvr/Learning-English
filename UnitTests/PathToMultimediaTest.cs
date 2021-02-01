using NUnit.Framework;
using LElWPF.Core.Models;
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
               
                Assert.IsTrue(new PathToMultimedia__Test(id, path).PathSong == path + @"\song\" + id + ".mp3",
                           $"{new  PathToMultimedia__Test(id, path).PathSong}!=\n  {path}\\song\\{id}.mp3");
            }
            [Test]
            public void PathToMultimedia_Test_PathImg()
            {
                
                Assert.IsTrue(new PathToMultimedia__Test(id, path).PathImg == path + @"\img\" + id + ".jpg",
                   $"{new PathToMultimedia__Test(id, path).PathImg} == {path} + \\img\\ + {id} + .jpg");
            }
          
        }
    }
}