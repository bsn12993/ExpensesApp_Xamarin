using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Helpers
{
    public class CameraHelper
    {
        public async Task<MediaFile> TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable)
            {
                return null;
            }

            var options = new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Front,
                AllowCropping = true,
                PhotoSize = PhotoSize.Medium,
                CompressionQuality = 90,
                Directory = "demoCamara",
                Name = $"{Guid.NewGuid()}.jpg",
                SaveToAlbum = true
            };

            var file = await CrossMedia.Current.TakePhotoAsync(options);
            return file;
        }

        public async Task<MediaFile> ChoosePhoto()
        {
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                var file = await CrossMedia.Current.PickPhotoAsync();
                return file;
            }
            return null;
        }
    }
}
