using System;
using System.Collections.Generic;
using System.Security.Claims;
using JetBrains.Annotations;

namespace EEN.Web.AzureAD
{
    public class IdentityUpdater : IIdentityUpdater
    {
        public IdentityUpdater([NotNull] List<IIdentityUpdater> updaters)
        {
            if (updaters == null) throw new ArgumentNullException(nameof(updaters));
            Updaters = updaters;
        }

        [NotNull]
        protected List<IIdentityUpdater> Updaters { get; }

        public virtual void UpdateIdentity(ClaimsIdentity identity)
        {
            Updaters.ForEach(x => x.UpdateIdentity(identity));
        }
    }
}