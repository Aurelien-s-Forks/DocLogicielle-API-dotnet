using System.Collections.Generic;
using System.Linq;
using DocLogicielleAPI.Data;
using DocLogicielleAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocLogicielleAPI.Controllers
{
    /// <summary>
    /// Voitures Controllers
    /// </summary>
    [Route("api/voitures"), Produces("application/json")]
    [ApiController]
    public class VoituresController : ControllerBase
    {
        /// <summary>
        /// Récupération de la liste des voitures.
        /// </summary>
        /// <returns>Liste des voitures</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Voiture>> Get()
        {
            // Récupération des voitures sources
            List<Voiture> voitures = SourceData.Voitures();

            return Ok(voitures);
        }

        /// <summary>
        /// Récupération d'une voiture spécifique
        /// </summary>
        /// <param name="id">Identifiant de la voiture</param>
        /// <returns>Voiture spécifique</returns>
        [HttpGet("{id}"), Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Voiture> GetById(int id)
        {
            // Récupération des voitures sources
            List<Voiture> voitures = SourceData.Voitures();

            // Récupère la voiture en fonction de son identifiant
            var voiture = voitures.Where(v => v.Id == id).FirstOrDefault();

            // Vérification si la voiture est trouvée sinon return 404 NOT FOUND
            if (voiture is null)
            {
                return NotFound();
            }

            return Ok(voiture);
        }

        /// <summary>
        /// Ajout d'une voiture
        /// </summary>
        /// <param name="voiture"></param>
        /// <returns>Voiture créé</returns>
        [HttpPost, Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Voiture> Post([FromBody] Voiture voiture)
        {
            // Retourne la voiture passée dans le DTO
            return Ok(voiture);
        }

        /// <summary>
        /// Modification d'une voiture
        /// </summary>
        /// /// <param name="id">Identifiant de la voiture</param>
        /// <param name="voiture">Voiture modifiée</param>
        [HttpPut("{id}"), Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Voiture> Put(int id, [FromBody] Voiture voiture)
        {
            // Vérification si l'identifiant de la voiture 
            // dans la route correspond à l'identifiant de la voiture dans le DTO
            // sinon return 400 BAD REQUEST
            if (id != voiture.Id)
            {
                return BadRequest();
            }

            // Récupération des voitures sources
            List<Voiture> voitures = SourceData.Voitures();

            // Récupère la voiture à mettre à jour en fonction de son identifiant
            var voitureInList = voitures.Where(v => v.Id == id).FirstOrDefault();

            // Vérification si la voiture à mettre à jour est trouvée sinon return 404 NOT FOUND
            if (voitureInList is null)
            {
                return NotFound();
            }

            // Remplacement de la voiture par la nouvelle
            voitureInList = voiture;

            return Ok(voitureInList);
        }

        /// <summary>
        /// Supression d'une voiture
        /// </summary>
        /// <param name="id">Identifiant de la voiture</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            // Récupération des voitures sources
            List<Voiture> voitures = SourceData.Voitures();

            // Vérification si la voiture à supprimer est trouvée sinon return 404 NOT FOUND
            if(!voitures.Any(v => v.Id == id)){
                return NotFound();
            }

            // Suppression de la voiture en fonction de son identifiant dans la liste de voitures source.
            voitures.RemoveAll(v => v.Id == id);

            // Réponse OK mais vide.
            return Ok();
        }
    }
}
