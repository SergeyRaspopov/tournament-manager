﻿using Microsoft.AspNetCore.Authorization;
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

        #region Categories

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

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGenderCategory([FromBody] GenderCategory category)
        {
            try
            {
                var userId = User.Identity.Name;
                category = await _organizerService.AddGenderCategoryAsync(category, userId);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddWeightCategory([FromBody] WeightCategory category)
        {
            try
            {
                var userId = User.Identity.Name;
                category = await _organizerService.AddWeightCategoryAsync(category, userId);
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

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGenderCategoryGroup([FromBody] GenderCategoryGroup group)
        {
            try
            {
                var userId = User.Identity.Name;
                group = await _organizerService.UpdateGenderCategoryGroupAsync(group, userId);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateWeightCategoryGroup([FromBody] WeightCategoryGroup group)
        {
            try
            {
                var userId = User.Identity.Name;
                group = await _organizerService.UpdateWeightCategoryGroupAsync(group, userId);
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

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGenderCategoryGroup([FromBody] int groupId)
        {
            try
            {
                var userId = User.Identity.Name;
                var deleted = await _organizerService.DeleteGenderCategoryGroupAsync(groupId, userId);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteWeightCategoryGroup([FromBody] int groupId)
        {
            try
            {
                var userId = User.Identity.Name;
                var deleted = await _organizerService.DeleteWeightCategoryGroupAsync(groupId, userId);
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

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGenderCategory([FromBody] GenderCategory category)
        {
            try
            {
                var userId = User.Identity.Name;
                category = await _organizerService.UpdateGenderCategoryAsync(category, userId);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateWeightCategory([FromBody] WeightCategory category)
        {
            try
            {
                var userId = User.Identity.Name;
                category = await _organizerService.UpdateWeightCategoryAsync(category, userId);
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

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGenderCategory([FromBody] int categoryId)
        {
            try
            {
                var userId = User.Identity.Name;
                var category = await _organizerService.DeleteGenderCategoryAsync(categoryId, userId);
                return Ok(category);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteWeightCategory([FromBody] int categoryId)
        {
            try
            {
                var userId = User.Identity.Name;
                var category = await _organizerService.DeleteWeightCategoryAsync(categoryId, userId);
                return Ok(category);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #endregion

        [HttpGet("[action]")]
        public async Task<IActionResult> Tournaments()
        {
            try
            {
                var tournaments = await _organizerService.GetTournamentsAsync(User.Identity.Name);
                return Ok(tournaments);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddTournament([FromBody] Tournament tournament)
        {
            try
            {
                tournament = await _organizerService.AddTournamentAsync(tournament, User.Identity.Name);
                return Ok(tournament);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> AddDivisionGroup([FromBody] DivisionGroup divisionGroup)
        {
            try
            {
                divisionGroup = await _organizerService.AddDivisionGroupAsync(divisionGroup, User.Identity.Name);
                return Ok(divisionGroup);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
