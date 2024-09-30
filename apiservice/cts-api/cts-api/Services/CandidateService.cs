/* 
 *      Name:           CTS - Contact Tracking System 
 *      Description:    This class is product data model
 *      Author:         Wenhui Fan
 *      Created:        2024/09/26
 *      Last Updated:   2024/09/28
 */

using cts_api.Services.IServices;
using cts_app.Data.Data;
using cts_app.Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace cts_api.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _context;

        public CandidateService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all candidates asynchronously
        public async Task<IEnumerable<Candidate>> GetCandidatesAsync()
        {
            return await _context.Candidates.OrderByDescending(x=>x.Id).Take(15).ToListAsync();
        }
        public async Task<IEnumerable<Candidate>> GetCandidatesByConditionAsync(Candidate candidate)
        {
            return await _context.Candidates
                                .Where(x =>
                                    (string.IsNullOrEmpty(x.FirstName) || x.FirstName.Contains(candidate.FirstName)) &&
                                    (string.IsNullOrEmpty(x.LastName) || x.LastName.Contains(candidate.LastName)) &&
                                     (string.IsNullOrEmpty(x.Email) || x.Email.Contains(candidate.Email)) &&
                                    (string.IsNullOrEmpty(x.PhoneNumber) || x.PhoneNumber.Contains(candidate.PhoneNumber)) &&
                                    (string.IsNullOrEmpty(x.ZipCode) || x.ZipCode.Contains(candidate.ZipCode))
                                )
                                .OrderByDescending(x => x.Id)
                                .Take(15)
                                .ToListAsync();
        }

        // Get a single candidate by ID asynchronously
        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            return await _context.Candidates.FindAsync(id);
        }

        // Create a new candidate asynchronously
        public async Task<Candidate> CreateCandidateAsync(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync(); // Persist the changes asynchronously
            return candidate;
        }

        // Update an existing candidate asynchronously
        public async Task UpdateCandidateAsync(Candidate candidate)
        {
            _context.Entry(candidate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete a candidate by ID asynchronously
        public async Task DeleteCandidateAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
