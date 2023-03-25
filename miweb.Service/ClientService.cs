using miweb.Domain.Dto;
using miweb.Domain.Model;
using miweb.Persistence.dataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;




namespace miweb.Service
{
    public class ClientService : IClientService
    {
        public List<ClientViewModel> GetListClient()
        {

            using (var context = new ecommerceEntities1())
            {

                List<ClientViewModel> lista = (from _cli in context.Cliente
                                               where _cli.Activo == true
                                               select new ClientViewModel
                                               {
                                                   ClienteId = _cli.ClienteId,
                                                   Nombre = _cli.Nombre,
                                                   Contrasena = _cli.Contrasena,
                                                   Email = _cli.Email,
                                                   Rol = _cli.Rol,
                                                   Telefono = _cli.Telefono,
                                                   Activo = _cli.Activo
                                               }).ToList();

                return lista;
            }
        }
        public Cliente Create(ClienteDto clienteDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Cliente cliente = context.Cliente.FirstOrDefault
                    (c => c.Email.ToUpper().Trim() == clienteDto.Email.ToUpper().Trim());

                if (cliente?.Activo == true)
                {
                    throw new Exception($"Ya existe un correo registrado");
                }
                else if (cliente?.Activo == false)
                {
                    cliente.Activo = true;

                    context.Entry(cliente).State = EntityState.Modified;
                    context.SaveChanges();
                    return cliente;
                }
                else
                {
                    var newcliente = new Cliente();
                    {
                        newcliente.Nombre = clienteDto.Nombre;
                        newcliente.Email = clienteDto.Email;
                        newcliente.Telefono = clienteDto.Telefono;
                        newcliente.Contrasena = clienteDto.Contrasena;
                        newcliente.Rol = clienteDto.Rol;
                        newcliente.Activo = true;
                    };
                    context.Cliente.Add(newcliente);
                    context.SaveChanges();
                    return newcliente;
                }
            }

        }
        public void Update(ClienteDto clienteDto)
        {
            using (var context = new ecommerceEntities1())
            {
                Cliente actualizar = context.Cliente.FirstOrDefault
                    (c => c.Email.ToUpper().Trim() == clienteDto.Email.ToUpper().Trim() && c.Activo == true);
                {
                    if (actualizar == null)
                    {
                        throw new Exception($"Cliente no se encuentra registrado");
                    }
                    else
                    {
                        actualizar.ClienteId = actualizar.ClienteId;
                        actualizar.Email = actualizar.Email;
                        actualizar.Nombre = clienteDto.Nombre;
                        actualizar.Telefono = clienteDto.Telefono;
                        actualizar.Contrasena = clienteDto.Contrasena;
                        actualizar.Rol = clienteDto.Rol;
                        actualizar.Activo = true;

                        context.Entry(actualizar).State = EntityState.Modified;
                        context.SaveChanges();

                    }


                }
            }
        }
    }

    public interface IClientService
    {
        List<ClientViewModel> GetListClient();
        Cliente Create(ClienteDto clienteDto);
        void Update(ClienteDto clienteDto);
    }
}
