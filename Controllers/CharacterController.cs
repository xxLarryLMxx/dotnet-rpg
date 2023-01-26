using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }
        
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet]
        [Route("GetTheFirstOne/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            return Ok(await _characterService.GetCharactersById(id));
        }

        [HttpPost]
        [Route("AddCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        [Route("UpdateCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter){
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id){
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}