using FluentValidator;
using Shop.Domain.Commands;
using Shop.Domain.Commands.CustomerCommands;
using Shop.Domain.Commands.ProductCommands;
using Shop.Domain.Entities;
using Shop.Domain.Enums;
using Shop.Domain.Repositories;
using Shop.Domain.ValueObjects;
using Shop.Shared.Commands;

namespace Shop.Domain.Handlers
{
    public class VoucherHandler : Notifiable,
    ICommandHandler<CreateVoucherCommand>,
    ICommandHandler<UpdateVoucherCommand>
    {
        private readonly IVoucherRepository _repository;
        public VoucherHandler(IVoucherRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateVoucherCommand command)
        {
            try
            {
                command.Validation();

                AddNotifications(command.Notifications);

                var voucher = new Voucher(command.Code, command.Percent, command.DiscountValue,
                command.Quantity, command.DiscountType, command.Active, command.Used,
                command.ExpiryOn);

                if (Invalid)
                    return new CommandResult(
                        false,
                        "Favor corrigir os campos abaixo",
                        Notifications);

                await _repository.Save(voucher);

                return new CommandResult(true, "Voucher cadastrado com sucesso!", new
                {
                    Id = voucher.Id,
                    Code = voucher.Code,
                    Percent = voucher.Percent,
                    DiscountValue = voucher.DiscountValue,
                    Quantity = voucher.Quantity,
                    DiscountType = voucher.DiscountType,
                    Active = voucher.Active,
                    Used = voucher.Used,
                    ExpiryOn = voucher.ExpiryOn
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new CommandResult(
                false,
                "Erro ao processar os campos da requisição",
                Notifications);
            }
        }

        public async Task<ICommandResult> Handle(UpdateVoucherCommand command)
        {
            try
            {
                command.Validation();

                AddNotifications(command.Notifications);

                var id = Guid.Parse(command.Id);

                var voucher = new Voucher(id, command.Code, command.Percent, command.DiscountValue,
                command.Quantity, command.DiscountType, command.Active, command.Used,
                command.ExpiryOn);

                if (Invalid)
                    return new CommandResult(
                        false,
                        "Favor corrigir os campos abaixo",
                        Notifications);

                await _repository.Update(voucher);

                return new CommandResult(true, "Voucher atualizado com sucesso!", new
                {
                    Id = voucher.Id,
                    Code = voucher.Code,
                    Percent = voucher.Percent,
                    DiscountValue = voucher.DiscountValue,
                    Quantity = voucher.Quantity,
                    DiscountType = voucher.DiscountType,
                    Active = voucher.Active,
                    Used = voucher.Used,
                    ExpiryOn = voucher.ExpiryOn
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new CommandResult(
                false,
                "Erro ao processar os campos da requisição",
                Notifications);
            }
        }
    }
}