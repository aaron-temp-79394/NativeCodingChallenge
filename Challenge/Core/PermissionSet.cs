using System;
using System.Linq;

namespace Challenge {
    public class PermissionSet : IEquatable<PermissionSet> {
        // permission is byte, following unix convention:
        /*
         * 0 No Permission
         * 1 Execute
         * 2 Write
         * 3 Execute + Write
         * 4 Read
         * 5 Read + Execute
         * 6 Read +Write
         * 7 Read + Write +Execute
         */
        // initializes to all 0's
        public byte[] Permissions = new byte[100];

        public byte[] Serialize() {
            return Permissions;
        }

        public static PermissionSet Deserialize(byte[] bytes) {
            // guards
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            if (bytes.Length != 100) throw new ArgumentOutOfRangeException(
                paramName: nameof(bytes),
                message: "bytes parameter must contain exactly 100 elements"
                );

            return new PermissionSet() {
                Permissions = bytes
            };
        }

        // IEquatable implementation, additional overrides also recommended see https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals

        public bool Equals(PermissionSet other) {
            if (other == null) return false;

            return Permissions.SequenceEqual(other.Permissions);
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;

            PermissionSet psObj = obj as PermissionSet;
            if (psObj == null) return false;
            else return Equals(psObj);
        }

        public static bool operator ==(PermissionSet ps1, PermissionSet ps2) {
            if (((object)ps1) == null || ((object)ps2) == null) {
                return Object.Equals(ps1, ps2);
            }

            return ps1.Equals(ps2);
        }

        public static bool operator !=(PermissionSet ps1, PermissionSet ps2) {
            if (((object)ps1) == null || ((object)ps2) == null) {
                return !Object.Equals(ps1, ps2);
            }

            return !ps1.Equals(ps2);
        }
    }
}
