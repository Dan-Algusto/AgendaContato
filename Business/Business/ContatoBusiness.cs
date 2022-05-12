using DAL.DTOs;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Business
{
    public class ContatoBusiness
    {
        public List<ContatoDTO> ObterTodosContatos()
        {
            ContatoRepository contatoRepository = new ContatoRepository();
            return contatoRepository.ObterTodosContatos();
        }

        public ContatoDTO PesquisarContato(string Nome)
        {
            ContatoRepository contatoRepository = new ContatoRepository();
            return contatoRepository.PesquisarContato(Nome);

        }
        public void CriarContato(ContatoDTO contatoDTO)
        {
            ContatoRepository contatoRepository = new ContatoRepository();
            contatoRepository.AdicionarContato(contatoDTO);
        }
        public void RemoverContato(int Id)
        {
            ContatoRepository contatoRepository = new ContatoRepository();
            contatoRepository.RemoverContato(Id);
        }

        
            
        
            

    
        



    }
}
