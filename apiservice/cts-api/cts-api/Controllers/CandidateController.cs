/* 
 *      Name:           CTS - Contact Tracking System 
 *      Description:    This class is product data model
 *      Author:         Wenhui Fan
 *      Created:        2024/09/26
 *      Last Updated:   2024/09/28
 */

using cts_api.Services.IServices;
using cts_app.Data.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cts_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // GET: api/candidate
        [HttpGet("GetCandidates")]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetAllCandidates()
        {
            var candidates = await _candidateService.GetCandidatesAsync();

            return Ok(candidates);
        }

        // GET: api/candidate/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetCandidateById/{id:int}")]
        public async Task<ActionResult<Candidate>> GetCandidateById(int id)
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("GetCandidatesByParams")]
        public async Task<ActionResult<ActionResult<IEnumerable<Candidate>>>> GetCandidatesByParams([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidates = await _candidateService.GetCandidatesByConditionAsync(candidate);

            return Ok(candidates);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("CreateCandidate")]
        public async Task<ActionResult<Candidate>> CreateCandidate([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCandidate = await _candidateService.CreateCandidateAsync(candidate);

            // Return 201 Created with the location of the newly created resource
            return CreatedAtRoute("GetCandidateById", new { id = createdCandidate.Id }, createdCandidate);
        }

        // PUT api/<CandidateController>/5
        [HttpPut("UpdateCandidate/{id:int}")]
        public async Task<ActionResult> UpdateCandidate(int id, [FromBody] Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest("Candidate ID mismatch");
            }

            var existingCandidate = await _candidateService.GetCandidateByIdAsync(id);
            if (existingCandidate == null)
            {
                return NotFound();
            }

            await _candidateService.UpdateCandidateAsync(candidate);

            return NoContent(); // 204 No Content on successful update
        }

        // DELETE: api/candidate/{id}
        [HttpDelete("DeleteCandidate/{id:int}")]
        public async Task<ActionResult> DeleteCandidate(int id)
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            await _candidateService.DeleteCandidateAsync(id);

            return NoContent(); // 204 No Content on successful deletion
        }
    }
}
