using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.Models;
using WSVenta.Models.Request;
using WSVenta.Models.Response;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                
                using (VentaRealContext db = new VentaRealContext())
                {
                    var lst = db.Cliente.OrderByDescending(d => d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                    
                }
            }
            catch(Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpPost]
        public IActionResult Add([FromBody]ClienteRequest cModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {

                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = cModel.Nombre;
                    db.Cliente.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oCliente;

                }

            }
            catch(Exception ex)
            {

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest cModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {

                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Cliente.Find(cModel.id);

                    oCliente.Nombre = cModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oCliente;

                }

            }
            catch (Exception ex)
            {

            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {

                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Cliente.Find(id);

                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }

            }
            catch (Exception ex)
            {

            }
            return Ok(oRespuesta);
        }

    }
}