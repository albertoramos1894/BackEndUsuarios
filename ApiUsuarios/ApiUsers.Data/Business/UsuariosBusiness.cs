using ApiUsers.Data.Dtos;
using ApiUsers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsers.Data.Business
{
    public class UsuariosBusiness
    {
        public GeneralResponse<List<UsuarioDto>> GetAll()
        {
            GeneralResponse<List<UsuarioDto>> response = new GeneralResponse<List<UsuarioDto>>();
            List<UsuarioDto> usuarios = new List<UsuarioDto>();
            try
            {               
                using(var context = new BdusersContext())
                {
                    var listUsuarios = context.Usuarios.Where(x=>x.Activo).ToList();
                    if (listUsuarios.Count > 0)
                    {
                        foreach(var item in listUsuarios)
                        {
                            usuarios.Add(new UsuarioDto()
                            {
                                Activo= item.Activo,
                                Email= item.Email,
                                FechaNacimiento = item.FechaNacimiento,
                                Id=item.Id,
                                Nombre=item.Nombre,
                                Sexo=item.Sexo,
                                UserName = item.UserName
                            });
                        }
                    }
                    response.Data = usuarios;
                    response.Success = true;
                    response.Message = usuarios.Count > 0 ? "Se recupero el listado de usuarios." : "No existen registros de usuarios.";
                    response.Code = (int) HttpStatusCode.OK;
                }
            }catch(Exception ex)
            {
                response.Code = 500;
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public GeneralResponse<UsuarioDto>GetUsuario(int IdUsuario)
        {
            GeneralResponse<UsuarioDto> response = new GeneralResponse<UsuarioDto>();
            UsuarioDto usuario;
            try
            {
                using (var context = new BdusersContext())
                {
                    var usuarioDb = context.Usuarios.Where(x=>x.Id == IdUsuario).FirstOrDefault();
                    if (usuarioDb != null)
                    {
                        usuario = new UsuarioDto()
                        {
                            Id = usuarioDb.Id,
                            Activo= usuarioDb.Activo,
                            Email= usuarioDb.Email,
                            FechaNacimiento = usuarioDb.FechaNacimiento,
                            Nombre= usuarioDb.Nombre,
                            Sexo= usuarioDb.Sexo,
                            UserName = usuarioDb.UserName   
                        };

                        response.Data = usuario;
                    }
                    
                    response.Success = true;
                    response.Message = usuarioDb != null ? "Se recupero el usuario." : "No existen registro de usuario.";
                    response.Code = (int)HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
        public GeneralResponse <Object> PostUsuario(UsuarioDto request)
        {
            GeneralResponse<Object> response = new GeneralResponse<Object>();            
            try
            {
                using (var context = new BdusersContext())
                {
                    Usuario usuario = new Usuario()
                    {                        
                        Activo= request.Activo,
                        Email= request.Email,
                        Nombre = request.Nombre,
                        Sexo = request.Sexo,
                        UserName= request.UserName
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    response.Success = true;
                    response.Message = "El usuario se creo exitosamente.";
                    response.Code = (int)HttpStatusCode.Created;
                }
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public GeneralResponse<Object> DeleteUsuario(int IdUsuario)
        {
            GeneralResponse<Object> response = new GeneralResponse<Object>();            
            try
            {
                using (var context = new BdusersContext())
                {
                    var usuarioDb = context.Usuarios.Where(x => x.Id == IdUsuario).FirstOrDefault();
                    if (usuarioDb != null)
                    {
                        context.Usuarios.Remove(usuarioDb);
                        context.SaveChanges();
                    }

                    response.Success = true;
                    response.Message = usuarioDb != null ? "Se elimino el usuario." : "No existen registro de usuario.";
                    response.Code = (int)HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
