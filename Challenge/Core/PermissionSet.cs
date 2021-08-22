using System;
using System.Linq;

namespace Challenge {
    /// <summary>
    /// <para>Holds fixed list of 100 user permissions. Permissions follow unix convention:</para>
    /// <para>0 No Permission</para>
    /// <para>1 Execute</para>
    /// <para>2 Write</para>
    /// <para>3 Execute + Write</para>
    /// <para>4 Read</para>
    /// <para>5 Read + Execute</para>
    /// <para>6 Read +Write</para>
    /// </summary>
    public class PermissionSet : IEquatable<PermissionSet> {
        // initializes to all 0's
        /// <summary>
        /// User permissions
        /// </summary>
        public byte[] Permissions = new byte[100];

        /// <summary>
        /// Serialize
        /// </summary>
        /// <returns>Byte array</returns>
        public byte[] Serialize() {
            return Permissions;
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="bytes">Byte array</param>
        /// <returns>PermissionSet</returns>
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

        public override int GetHashCode() {
            return Permissions.GetHashCode();
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
