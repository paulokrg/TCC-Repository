using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace Logistics.ProductPlugin.LogisticsCore
{
    public abstract class ActionCore : CodeActivity
    {
        public IWorkflowContext WorkflowContext { get; set; }
        public IOrganizationServiceFactory ServiceFactory { get; set; }
        public IOrganizationService Service { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            WorkflowContext = context.GetExtension<IWorkflowContext>();
            ServiceFactory = context.GetExtension<IOrganizationServiceFactory>();
            Service = ServiceFactory.CreateOrganizationService(WorkflowContext.UserId);

            ExecuteAction(context);
        }

        public abstract void ExecuteAction(CodeActivityContext context);
    }
}
