using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FastFoodController : ControllerBase
    {
       public FastFoodContext Context {get; set;}
        public FastFoodController(FastFoodContext context)
        
        {
           Context=context;
        }

        [Route("PreuzmiRestoran")]
        [HttpGet]
        public async Task<List<FastFood>> PreuzmiRestoran(){
            return await Context.Restorani.Include(p=> p.Lokacije).Include(p=>p.Racuni).ToListAsync();
        }
        [Route("PreuzmiLokacije/{idRestorana}")]
        [HttpGet]
        public async Task<List<Lokacija>> PreuzmiLokacije(int idRestorana){
            return await Context.Lokacije.Where(lok=>lok.FastFood.ID==idRestorana).ToListAsync();
        }
        [Route("PreuzmiRacune/{idRestorana}")]
        [HttpGet]
        public async Task<List<Obracun>> PreuzmRacune(int idRestorana){
            return await Context.Racuni.Where(rac=>rac.FastFood.ID==idRestorana).ToListAsync();
        }


        [Route("UpisiRestoran")]
        [HttpPost]
        public async Task UpisiRestoran([FromBody]FastFood res){
        Context.Restorani.Add(res);
        await Context.SaveChangesAsync();
        }
         [Route("UpisiLokaciju/{idRestorana}")]
        [HttpPost]
        public async Task UpisiLokaciju(int idRestorana,[FromBody]Lokacija lok)
        {
            var res=await Context.Restorani.FindAsync(idRestorana);
            lok.FastFood=res;
          Context.Lokacije.Add(lok);
          await Context.SaveChangesAsync();
        }
        [Route("UpisiRacune/{idRestorana}")]
        [HttpPost]
        public async Task UpisiRacune(int idRestorana,[FromBody]Obracun rac)
        {
            var res=await Context.Restorani.FindAsync(idRestorana);
            rac.FastFood=res;
          Context.Racuni.Add(rac);
          await Context.SaveChangesAsync();
        }


        [Route("IzmeniRestoran")]
        [HttpPut]
        public async Task IzmeniVrt([FromBody]FastFood res)
        {
           /* var stariRestoran= await Context.Restorani.FindAsync(res.ID);
            stariRestoran.Kapacitet=res.Kapacitet;
            stariRestoran.Naziv=res.Naziv;
            stariRestoran.M=res.M;
            stariRestoran.N=res.N;
            stariRestoran.Cena=res.Cena;*/
            Context.Update<FastFood>(res);
            await Context.SaveChangesAsync();
        }
        [Route("IzmeniLokaciju")]
        [HttpPut]
        public async Task IzmeniLokaciju([FromBody] Lokacija lok)
        {
            Context.Update<Lokacija>(lok);
            await Context.SaveChangesAsync();
        }
          [Route("IzmeniRacune")]
        [HttpPut]
        public async Task IzmeniRacune([FromBody] Obracun rac)
        {
            Context.Update<Obracun>(rac);
            await Context.SaveChangesAsync();
        }


          [Route("IzbrisiRestoran")]
        [HttpDelete]
        public async Task IzbrisiRestoran(int id)
        {
           var nizLokacija=Context.Lokacije.Where(l=>l.FastFood.ID==id);
           await nizLokacija.ForEachAsync(l=>{
             Context.Remove(l);
           });
           var nizRacuna=Context.Racuni.Where(l=>l.FastFood.ID==id);
           await nizRacuna.ForEachAsync(l=>{
             Context.Remove(l);
           });
           var restoran=await Context.Restorani.FindAsync(id);
           Context.Remove(restoran);
           await Context.SaveChangesAsync();
        }
        [Route("IzbrisiLokaciju/{idRestorana}")]
        [HttpDelete]
        public async Task IzbrisiLokaciju(int id)
        {
           var lok = await Context.Lokacije.FindAsync(id);
            Context.Remove(lok);
            await Context.SaveChangesAsync();
        }
        [Route("IzbrisiRacun/{idRestorana}")]
        [HttpDelete]
        public async Task IzbrisiRacun(int id)
        {
           var rac = await Context.Lokacije.FindAsync(id);
            Context.Remove(rac);
            await Context.SaveChangesAsync();
        }

       


    }
}
