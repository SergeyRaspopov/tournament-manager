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
        //add group
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
        //add category
        public async Task<AgeCategory> AddAgeCategoryAsync(AgeCategory ageCategory, string userId)
        {
            var group = await GetAgeCategoryGroupAsync(ageCategory.AgeCategoryGroupId, userId);
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
        //update group
        public async Task<AgeCategoryGroup> UpdateAgeCategoryGroupAsync(AgeCategoryGroup group, string userId)
        {
            var stored = await GetAgeCategoryGroupAsync(group.Id, userId);
            stored.Name = group.Name;
            _context.Update(stored);
            await _context.SaveChangesAsync();
            return stored;
        }

        public async Task<ExperienceCategoryGroup> UpdateExperienceCategoryGroupAsync(ExperienceCategoryGroup group, string userId)
        {
            var stored = await GetExperienceCategoryGroupAsync(group.Id, userId);
            stored.Name = group.Name;
            _context.Update(stored);
            await _context.SaveChangesAsync();
            return stored;
        }

        //delete group
        public async Task<AgeCategoryGroup> DeleteAgeCategoryGroupAsync(int groupId, string userId)
        {
            var group = await GetAgeCategoryGroupAsync(groupId, userId);
            var entity = _context.Remove(group);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<ExperienceCategoryGroup> DeleteExperienceCategoryGroupAsync(int groupId, string userId)
        {
            var group = await GetExperienceCategoryGroupAsync(groupId, userId);
            var entity = _context.Remove(group);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        //update category
        public async Task<AgeCategory> UpdateAgeCategoryAsync(AgeCategory category, string userId)
        {
            var existing = await GetAgeCategoryAsync(category.Id, userId);//this is more for cheking that category is for this user
            if (existing != null)
            {
                existing.Name = category.Name;
                existing.MinAge = category.MinAge;
                existing.MaxAge = category.MaxAge;
                _context.Update(existing);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public async Task<ExperienceCategory> UpdateExperienceCategoryAsync(ExperienceCategory category, string userId)
        {
            var existing = await GetExperienceCategoryAsync(category.Id, userId);//this is more for cheking that category is for this user
            if (existing != null)
            {
                existing.Name = category.Name;
                _context.Update(existing);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        //delete category
        public async Task<AgeCategory> DeleteAgeCategoryAsync(int categoryId, string userId)
        {
            var existing = await GetAgeCategoryAsync(categoryId, userId);
            var entry = _context.Remove(existing);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<ExperienceCategory> DeleteExperienceCategoryAsync(int categoryId, string userId)
        {
            var existing = await GetExperienceCategoryAsync(categoryId, userId);
            var entry = _context.Remove(existing);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }



        private async Task<AgeCategoryGroup> GetAgeCategoryGroupAsync(int id, string userId)
        {
            return await _context.AgeCategoryGroups.FirstOrDefaultAsync(g => g.ApplicationUserId == userId && g.Id == id);
        }

        private async Task<ExperienceCategoryGroup> GetExperienceCategoryGroupAsync(int id, string userId)
        {
            return await _context.ExperienceCategoryGroups.FirstOrDefaultAsync(g => g.ApplicationUserId == userId && g.Id == id);
        }

        private async Task<AgeCategory> GetAgeCategoryAsync(int categoryId, string userId)
        {
            var category =
                await (from ac in _context.AgeCategories
                       join ag in _context.AgeCategoryGroups on ac.AgeCategoryGroupId equals ag.Id
                       where ac.Id == categoryId && ag.ApplicationUserId == userId
                       select ac)
                       .SingleAsync();
            return category;
        }

        private async Task<ExperienceCategory> GetExperienceCategoryAsync(int id, string userId)
        {
            var category =
                await (from ec in _context.ExperienceCategories
                       join eg in _context.ExperienceCategoryGroups on ec.ExperienceCategoryGroupId equals eg.Id
                       where ec.Id == id && eg.ApplicationUserId == userId
                       select ec).SingleAsync();
            return category;
        }
    }
}
