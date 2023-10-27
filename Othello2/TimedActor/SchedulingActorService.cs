using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;

using System.Fabric;

using TimedActor.Interfaces;

namespace TimedActor
{
    internal class SchedulingActorService : ActorService
    {
        protected async override Task RunAsync(CancellationToken cancellationToken)
        {
            await base.RunAsync(cancellationToken);

            var proxy = ActorProxy.Create<ITimedActor>(new ActorId(0));
            await proxy.RegisterReminder(this.Context.NodeContext.NodeName);
        }

        public SchedulingActorService(StatefulServiceContext context, ActorTypeInformation actorTypeInfo, Func<ActorService, ActorId, ActorBase> actorFactory = null, Func<ActorBase, IActorStateProvider, IActorStateManager> stateManagerFactory = null, IActorStateProvider stateProvider = null, ActorServiceSettings settings = null)
       : base(context, actorTypeInfo, actorFactory, stateManagerFactory, stateProvider, settings)
        {
            Console.WriteLine("FOOO");
        }
    }
}
