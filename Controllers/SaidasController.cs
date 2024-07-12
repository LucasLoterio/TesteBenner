using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteBenner.Data;
using TesteBenner.Models;

namespace TesteBenner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaidasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SaidasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Saidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saida>>> GetSaida()
        {
            return await _context.Saida.ToListAsync();
        }

        // GET: api/Saidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Saida>> GetSaida(int id)
        {
            var saida = await _context.Saida.FindAsync(id);

            if (saida == null)
            {
                return NotFound();
            }

            return saida;
        }

        // PUT: api/Saidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaida(int id, Saida saida)
        {
            if (id != saida.Id)
            {
                return BadRequest();
            }

            _context.Entry(saida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaidaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Saidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Saida>> PostSaida(Saida saida)
        {
            var veiculo = await _context.Veiculo.ToListAsync();
            foreach (var carro in veiculo)
            {
                if(carro.Placa == saida.Placa && carro.HoraSaida == null)
                {
                    if(saida.HoraSaida < carro.HoraEntra)
                    {
                        return BadRequest();
                    }
                    carro.HoraSaida = saida.HoraSaida;

                    var valorHoraInical = 1;
                    carro.valorTotal = valorHoraInical;
                    var valorHoraAdicional = 1;
                    TimeSpan tempoTotal = (TimeSpan)(saida.HoraSaida - carro.HoraEntra);
                    tempoTotal = new TimeSpan(tempoTotal.Hours, tempoTotal.Minutes, 0);
                    carro.tempo = tempoTotal;
                    if (tempoTotal <= TimeSpan.FromMinutes(30))
                    {
                         carro.valorTotal = 1;
                        return CreatedAtAction("GetSaida", new { id = saida.Id }, saida);
                    }


                    while (tempoTotal.TotalHours > 0)
                    {
                        carro.valorTotal += valorHoraAdicional;
                        tempoTotal -= (TimeSpan.FromHours(1) + TimeSpan.FromMinutes(10));
                    }

                    _context.Saida.Add(saida);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetSaida", new { id = saida.Id }, saida);

                }
            }


             return BadRequest();
            
        }

        
        // DELETE: api/Saidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaida(int id)
        {
            var saida = await _context.Saida.FindAsync(id);
            if (saida == null)
            {
                return NotFound();
            }

            _context.Saida.Remove(saida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaidaExists(int id)
        {
            return _context.Saida.Any(e => e.Id == id);
        }
    }
}
