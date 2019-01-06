using System.Collections.Generic;
using System.Linq;
using Elsa.Models;

namespace Elsa.Extensions
{
    public static class WorkflowExtensions
    {
        public static bool IsDefinition(this Workflow workflow) => workflow.Metadata.ParentId == null;
        public static bool IsInstance(this Workflow workflow) => !workflow.IsDefinition();

        public static bool IsHalted(this Workflow workflow) =>
            workflow.Status == WorkflowStatus.Halted;
        
        public static bool IsFaulted(this Workflow workflow) =>
            workflow.Status == WorkflowStatus.Aborted ||
            workflow.Status == WorkflowStatus.Faulted;

        public static bool IsFinished(this Workflow workflow) =>
            workflow.Status == WorkflowStatus.Finished;

        public static IEnumerable<IActivity> GetStartActivities(this Workflow workflow)
        {
            var query =
                from activity in workflow.Activities
                where !workflow.Connections.Select(x => x.Target.Activity).Contains(activity)
                select activity;

            return query;
        }
    }
}