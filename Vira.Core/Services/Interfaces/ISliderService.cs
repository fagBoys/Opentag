using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.DataLayer.Entities.Slider;

namespace Berlance.Core.Services.Interfaces
{
    public interface ISliderService
    {

        List<Slider> GetAllSlider();
        Slider GetSliderById(int sliderId);


        #region Admin

        int AddSlider(Slider slider, IFormFile imageSlider, IFormFile phoneImageName);
        void DeleteSlider(int id);
        #endregion


    }
}
