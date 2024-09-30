/* 
 *      Name:           CTS - Contact Tracking System 
 *      Description:    This class is product data model
 *      Author:         Wenhui Fan
 *      Created:        2024/09/26
 *      Last Updated:   2024/09/28
 */

using cts_app.Data.Data.Models;

namespace cts_api.Services.IServices
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetCandidatesAsync();
        Task<IEnumerable<Candidate>> GetCandidatesByConditionAsync(Candidate candidate);
        Task<Candidate> GetCandidateByIdAsync(int id);
        Task<Candidate> CreateCandidateAsync(Candidate candidate);
        Task UpdateCandidateAsync(Candidate candidate);
        Task DeleteCandidateAsync(int id);
    }
}
