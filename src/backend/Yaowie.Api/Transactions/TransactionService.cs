using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yaowie.Api.Users;

namespace Yaowie.Api.Transactions
{
    public interface ITransactionService
    {
        Task CreateTransaction(TransactionCreationDto dto);
    }

    public record TransactionCreationDto(Guid Id, decimal Value, string Receiver, string Sender, DateTime date);

    public class TransactionService : ITransactionService
    {
        private readonly IUserRepository userRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IEventQueue eventQueue;

        public TransactionService(IUserRepository userRepository, ITransactionRepository transactionRepository, IEventQueue eventQueue)
        {
            this.userRepository = userRepository;
            this.transactionRepository = transactionRepository;
            this.eventQueue = eventQueue;
        }

        public async Task CreateTransaction(TransactionCreationDto dto)
        {
            var receiver = userRepository.Entities.SingleOrDefault(u => u.PublicKey.SequenceEqual(Convert.FromBase64String(dto.Receiver))) ?? throw new NotFoundException();
            var sender = userRepository.Entities.SingleOrDefault(u => u.PublicKey.SequenceEqual(Convert.FromBase64String(dto.Sender))) ?? throw new NotFoundException();

            
            Transaction transaction = Transaction.Create(dto.Id, dto.Value, receiver, sender, dto.date);
            await transactionRepository.Add(transaction);

            await eventQueue.Add(dto.Receiver, transaction);
        }



    }
}
