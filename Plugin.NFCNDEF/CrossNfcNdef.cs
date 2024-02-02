using System;
using System.Threading;
using Plugin.NfcNdef.Abstractions;

namespace Plugin.NfcNdef
{
    public partial class CrossNfcNdef
    {
        private static Lazy<INfc> _implementation = new Lazy<INfc>(CreateNfc, LazyThreadSafetyMode.PublicationOnly);
        public static INfc Current => _implementation.Value;

        private static INfc CreateNfc()
        {
#if IOS
            return new NfcImplementation();
#else
            throw NotImplementedInReferenceAssembly();
#endif
        }

        public static void Dispose()
        {
            if (_implementation != null && _implementation.IsValueCreated)
            {
                _implementation = new Lazy<INfc>(CreateNfc, LazyThreadSafetyMode.PublicationOnly);
            }
        }

        private static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}