using Inventware.Domain.Core2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventware.Domain.Core2.Factories
{
    public abstract class TextBlockFactory
    {
        protected string _Name;
        protected string _Content;
        protected bool _IsVisible;

        protected TextBlockFactory(string name, string content)
        {
            if (string.IsNullOrEmpty(name)){
                throw new ArgumentNullException("Nome do Bloco", "O Nome do Bloco não pode ser nulo ou vazio.");
            }

            if (string.IsNullOrEmpty(content)){
                throw new ArgumentNullException("Conteúdo do Bloco", "O Conteúdo do Bloco não pode ser nulo ou vazio.");
            }

            _Name = name;
            _Content = content;
        }

        public abstract TextBlock Create();
    }





    public class TextBlockToBeCreatedFactory : TextBlockFactory
    {
        private Guid _UserThatWhoCreatedBlock;


        public TextBlockToBeCreatedFactory(string name, string content, bool isVisible, Guid userWhoCreatedTheBlock)
            : base(name, content)
        {
            if (userWhoCreatedTheBlock == Guid.Empty)
            {
                throw new ArgumentNullException("Usuário da Requisição",
                    "O Usuário de Criação da Requisição não pode ser nulo ou vazio.");
            }
            _UserThatWhoCreatedBlock = userWhoCreatedTheBlock;
            _IsVisible = isVisible;
        }


        public override TextBlock Create()
        {
            return new TextBlock(null, null, _Name, _Content, _IsVisible, _UserThatWhoCreatedBlock, DateTime.Today,
                true, false, null, null);
        }
    }





    public class TextBlockToBeUpdatedFactory : TextBlockFactory
    {
        private Guid _UserThatWhoCreatedBlock;
        private Guid _UserThatWhoUpdatedBlock;
        private DateTime _CreatedOn;
        private Guid _Id;


        public TextBlockToBeUpdatedFactory(Guid id, string name, string content, bool isVisible, DateTime createdOn,
            Guid userWhoCreatedTheBlock, Guid userWhoUpdatedTheBlock) : base(name, content)
        {
            if (userWhoCreatedTheBlock == Guid.Empty)
            {
                throw new ArgumentNullException("Usuário da Requisição",
                    "O Usuário de Criação da Requisição não pode ser nulo ou vazio.");
            }
            if (userWhoUpdatedTheBlock == Guid.Empty)
            {
                throw new ArgumentNullException("Usuário da Requisição",
                    "O Usuário de Atualização da Requisição não pode ser nulo ou vazio.");
            }
            _Id = id;
            _UserThatWhoCreatedBlock = userWhoCreatedTheBlock;
            _UserThatWhoUpdatedBlock = userWhoUpdatedTheBlock;
            _CreatedOn = createdOn;
            _IsVisible = isVisible;
        }


        public override TextBlock Create()
        {
            return new TextBlock(_Id, null, _Name, _Content, _IsVisible, _UserThatWhoCreatedBlock, _CreatedOn,
                _IsVisible, false, DateTime.Today, _UserThatWhoUpdatedBlock);
        }
    }
}
