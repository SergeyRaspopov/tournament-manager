using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models.DatabaseModels;
using trmgr.Models.DatabaseModels.Organization;
using trmgr.Services;

namespace trmgr.Controllers
{
    [Authorize(Roles = "Organizer")]
    [Route("api/[controller]")]
    public class OrganizerController : Controller
    {
        private OrganizerService _organizerService;

        public OrganizerController(OrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AgeCategories()
        {
            try
            {
                var userId = User.Identity.Name;
                var ageCategories = await _organizerService.GetAgeCategoryGroupsAsync(userId);
                return Ok(ageCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExperienceCategories()
        {
            try
            {
                var userId = User.Identity.Name;
                var experienceCategories = await _organizerService.GetExperienceCategoryGroupsAsync(userId);
                return Ok(experienceCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GenderCategories()
        {
            try
            {
                var userId = User.Identity.Name;
                var genderCategories = await _organizerService.GetGenderCategoryGroupsAsync(userId);
                return Ok(genderCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
            
        [HttpGet("[action]")]
        public async Task<IActionResult> WeightCategories()
        {
            try
            {
                var userId = User.Identity.Name;
                var weightCategories = await _organizerService.GetWeightCategoryGroupsAsync(userId);
                return Ok(weightCategories);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region Add Category Group

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAgeCategoryGroup([FromBody] AgeCategoryGroup ageCategoryGroup)
        {
            try
            {
                var userId = User.Identity.Name;
                ageCategoryGroup.ApplicationUserId = userId;
                ageCategoryGroup =  await _organizerService.AddAgeCategoryGroupAsync(ageCategoryGroup);
                return Ok(ageCategoryGroup);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddExperienceCategoryGroup([FromBody] ExperienceCategoryGroup experienceCategoryGroup)
        {
            try
            {
                var userId = User.Identity.Name;
                experienceCategoryGroup.ApplicationUserId = userId;
                experienceCategoryGroup = await _organizerService.AddExperienceCategoryGroupAsync(experienceCategoryGroup);
                return Ok(experienceCategoryGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGenderCategoryGroup([FromBody] GenderCategoryGroup genderCategoryGroup)
        {
            try
            {
                var userId = User.Identity.Name;
                genderCategoryGroup.ApplicationUserId = userId;
                genderCategoryGroup = await _organizerService.AddGenderCategoryGroupAsync(genderCategoryGroup);
                return Ok(genderCategoryGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddWeightCategoryGroup([FromBody] WeightCategoryGroup weightCategoryGroup)
        {
            try
            {
                var userId = User.Identity.Name;
                weightCategoryGroup.ApplicationUserId = userId;
                weightCategoryGroup = await _organizerService.AddWeightCategoryGroupAsync(weightCategoryGroup);
                return Ok(weightCategoryGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Add Category

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAgeCategory([FromBody] AgeCategory ageCategory)
        {
            try
            {
                var userId = User.Identity.Name;
                ageCategory = await _organizerService.AddAgeCategoryAsync(ageCategory, userId);
                return Ok(ageCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddExperienceCategory([FromBody] ExperienceCategory category)
        {
            try
            {
                var userId = User.Identity.Name;
                category = await _organizerService.AddExperienceCategoryAsync(category, userId);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion

        #region Update Category Group

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAgeCategoryGroup([FromBody] AgeCategoryGroup group)
        {
            try
            {
                var userId = User.Identity.Name;
                group = await _organizerService.UpdateAgeCategoryGroupAsync(group, userId);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateExperienceCategoryGroup([FromBody] ExperienceCategoryGroup group)
        {
            try
            {
                var userId = User.Identity.Name;
                group = await _organizerService.UpdateExperienceCategoryGroupAsync(group, userId);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Delete Category Group

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAgeCategoryGroup([FromBody] int groupId)
        {
            try
            {
                var userId = User.Identity.Name;
                var deleted = await _organizerService.DeleteAgeCategoryGroupAsync(groupId, userId);
                return Ok(deleted);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteExperienceCategoryGroup([FromBody] int groupId)
        {
            try
            {
                var userId = User.Identity.Name;
                var deleted = await _organizerService.DeleteExperienceCategoryGroupAsync(groupId, userId);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Update Category

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAgeCategory([FromBody] AgeCategory ageCategory)
        {
            try
            {
                var userId = User.Identity.Name;
                ageCategory = await _organizerService.UpdateAgeCategoryAsync(ageCategory, userId);
                return Ok(ageCategory);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateExperienceCategory([FromBody] ExperienceCategory category)
        {
            try
            {
                var userId = User.Identity.Name;
                category = await _organizerService.UpdateExperienceCategoryAsync(category, userId);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        #endregion

        #region Delete Category

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAgeCategory([FromBody] int categoryId)
        {
            try
            {
                var userId = User.Identity.Name;
                var ageCategory = await _organizerService.DeleteAgeCategoryAsync(categoryId, userId);
                return Ok(ageCategory);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteExperienceCategory([FromBody] int categoryId)
        {
            try
            {
                var userId = User.Identity.Name;
                var category = await _organizerService.DeleteExperienceCategoryAsync(categoryId, userId);
                return Ok(category);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        #endregion
    }
}
