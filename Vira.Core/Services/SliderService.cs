using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.Convertors;
using Vira.Core.Generator;
using Vira.Core.Security;
using Vira.Core.Services.Interfaces;
using Vira.DataLayer.Context;
using Vira.DataLayer.Entities.Slider;
using Microsoft.AspNetCore.Http;

namespace Vira.Core.Services
{
    public class SliderService : ISliderService
    {
        private ViraContext _context;

        public SliderService(ViraContext context)
        {
            _context = context;
        }

        public List<Slider> GetAllSlider()
        {
           return _context.Sliders.ToList();
        }

        public Slider GetSliderById(int sliderId)
        {
            return _context.Sliders.FirstOrDefault(s=>s.SliderId == sliderId);
        }

        #region Admin

        public int AddSlider(Slider slider, IFormFile imageSlider , IFormFile phoneImageName)
        {
            slider.ImageName = "no-photo.jpg";
            slider.PhoneImageName = "no-photo.jpg";

            if (imageSlider != null && imageSlider.IsImage())
            {
                slider.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imageSlider.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Slider/Image/", slider.ImageName);
                //imagePath = imagePath + slider.ImageName;
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageSlider.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string tumnpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Slider/Thumb/", slider.ImageName);
                //tumnpath = tumnpath + slider.ImageName;
                imgResizer.Image_resize(imagePath, tumnpath, 274);
            }

            if (phoneImageName != null && phoneImageName.IsImage())
            {
                slider.PhoneImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(phoneImageName.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Slider/PhoneImage/", slider.PhoneImageName);
                //imagePath = imagePath + slider.ImageName;
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    phoneImageName.CopyTo(stream);
                }

            }

            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return slider.SliderId;

        }


        public void DeleteSlider(int id)
        {
            Slider slider = _context.Sliders.Find(id);

            string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Slider/Image/", slider.ImageName);
            //deleteimagePath = deleteimagePath + slider.ImageName;
            if (File.Exists(deleteimagePath))
            {
                File.Delete(deleteimagePath);
            }

            string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Slider/Thumb/", slider.ImageName);
            //deletethumbPath = deletethumbPath + slider.ImageName;
            if (File.Exists(deletethumbPath))
            {
                File.Delete(deletethumbPath);
            }

            _context.Sliders.Remove(slider);
            _context.SaveChanges();
        }
        #endregion
    }
}
