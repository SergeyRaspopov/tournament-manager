using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trmgr.DAL;
using trmgr.Models.DatabaseModels.Organization;

namespace trmgr.Services
{
    public class OrganizerService
    {
        private ApplicationDbContext _context;

        public OrganizerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgeCategoryGroup>> GetAgeCategoryGroupsAsync(string userId)
        {
            return await _context
                .AgeCategoryGroups
                .Where(acg => acg.ApplicationUserId == userId)
                .Include(acg => acg.AgeCategories)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExperienceCategoryGroup>> GetExperienceCategoryGroupsAsync(string userId)
        {
            return await _context
                .ExperienceCategoryGroups
                .Where(ecg => ecg.ApplicationUserId == userId)
                .Include(ecg => ecg.ExperienceCategories)
                .ToListAsync();
        }

        public async Task<IEnumerable<GenderCategoryGroup>> GetGenderCategoryGroupsAsync(string userId)
        {
            return await _context
                .GenderCategoryGroups
                .Where(gcg => gcg.ApplicationUserId == userId)
                .Include(gcg => gcg.GenderCategories)
                .ToListAsync();
        }

        public async Task<IEnumerable<WeightCategoryGroup>> GetWeightCategoryGroupsAsync(string userId)
        {
            return await _context
                .WeightCategoryGroups
                .Where(wcg => wcg.ApplicationUserId == userId)
                .Include(wcg => wcg.WeightCategories)
                .ToListAsync();
        }

        public async Task<AgeCategoryGroup> AddAgeCategoryGroupAsync(AgeCategoryGroup ageCategoryGroup)
        {
            _context.Add(ageCategoryGroup);
            await _context.SaveChangesAsync();
            return ageCategoryGroup;
        }

        public async Task<ExperienceCategoryGroup> AddExperienceCategoryGroupAsync(ExperienceCategoryGroup experienceCategoryGroup)
        {
            _context.Add(experienceCategoryGroup);
            await _context.SaveChangesAsync();
            return experienceCategoryGroup;
        }

        public async Task<GenderCategoryGroup> AddGenderCategoryGroupAsync(GenderCategoryGroup genderCategoryGroup)
        {
            _context.Add(genderCategoryGroup);
            await _context.SaveChangesAsync();
            return genderCategoryGroup;
        }

        public async Task<WeightCategoryGroup> AddWeightCategoryGroupAsync(WeightCategoryGroup wightCategoryGroup)
        {
            _context.Add(wightCategoryGroup);
            await _context.SaveChangesAsync();
            return wightCategoryGroup;
        }

        public async Task<AgeCategory> AddAgeCategoryAsync(AgeCategory ageCategory, string userId)
        {
            var group =  await _context
                .AgeCategoryGroups
                .FirstOrDefaultAsync(acg => acg.ApplicationUserId == userId && acg.Id == ageCategory.AgeCategoryGroupId);
            if (group != null)
            {
                _context.Add(ageCategory);
                await _context.SaveChangesAsync();
                return ageCategory;
            }
            throw new Exception("Could not add a category");//this should never happen
        }

        public async Task<ExperienceCategory> AddExperienceCategoryAsync(ExperienceCategory experienceCategory, string userId)
        {
            var group = await _context
                .ExperienceCategoryGroups
                .FirstOrDefaultAsync(acg => acg.ApplicationUserId == userId && acg.Id == experienceCategory.ExperienceCategoryGroupId);
            if (group != null)
            {
                _context.Add(experienceCategory);
                await _context.SaveChangesAsync();
                return experienceCategory;
            }
            throw new Exception("Could not add a category");//this should never happen
        }

        public async Task<GenderCategory> AddGenderCategoryAsync(GenderCategory genderCategory, string userId)
        {
            var group = await _context
                .GenderCategoryGroups
                .FirstOrDefaultAsync(acg => acg.ApplicationUserId == userId && acg.Id == genderCategory.GenderCategoryGroupId);
            if (group != null)
            {
                _context.Add(genderCategory);
                await _context.SaveChangesAsync();
                return genderCategory;
            }
            throw new Exception("Could not add a category");//this should never happen
        }

        public async Task<WeightCategory> AddWeightCategoryAsync(WeightCategory weightCategory, string userId)
        {
            var group = await _context
                .WeightCategoryGroups
                .FirstOrDefaultAsync(acg => acg.ApplicationUserId == userId && acg.Id == weightCategory.WeightCategoryGroupId);
            if (group != null)
            {
                _context.Add(weightCategory);
                await _context.SaveChangesAsync();
                return weightCategory;
            }
            throw new Exception("Could not add a category");//this should never happen
        }
    }
}
