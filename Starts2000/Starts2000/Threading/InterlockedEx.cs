using System;
using System.Threading;

namespace Starts2000.Threading
{
    ///<summary>
    ///Provides atomic operations for variables that are shared by multiple threads.
    ///</summary>
    public static class InterlockedEx
    {

        #region Convenience Wrappers

        ///<summary>Compares two values for equality and, if they are equal, replaces one of the values.</summary>
        ///<return>Returns true if the value in <paramref name="val"/> was equal the the value of <paramref name="if"/>.</return>
        ///<param name="val">The destination, whose value is compared with <paramref name="if"/> and possibly replaced with <paramref name="then"/>.</param>
        ///<param name="if">The value that is compared to the value at <paramref name="val"/>.</param>
        ///<param name="then">The value that might get placed into <paramref name="val"/>.</param>
        public static bool IfThen(ref int val, int @if, int @then)
        {
            return Interlocked.CompareExchange(ref val, @then, @if) == @if;
        }

        ///<summary>Compares two values for equality and, if they are equal, replaces one of the values.</summary>
        ///<remarks>The previous value in <paramref name="val"/> is returned in <paramref name="prevVal"/>.</remarks>
        ///<return>Returns true if the value in <paramref name="val"> was equal the the value of <paramref name="if"/>.</return>
        ///<param name="val">The destination, whose value is compared with <paramref name="if"/> and possibly replaced with <paramref name="then"/>.</param>
        ///<param name="if">The value that is compared to the value at <paramref name="val"/>.</param>
        ///<param name="then">The value that might get placed into <paramref name="val"/>.</param>
        ///<param name="prevVal">The previous value that was in <paramref name="val"/> prior to calling this method.</param>
        public static bool IfThen(ref int val, int @if, int @then, out int prevVal)
        {
            prevVal = Interlocked.CompareExchange(ref val, @then, @if);
            return prevVal == @if;
        }

        public static bool IfThen<T>(ref T val, T @if, T @then) where T : class
        {
            return Interlocked.CompareExchange(ref val, @then, @if) == @if;
        }

        public static bool IfThen<T>(ref T val, T @if, T @then, out T prevVal) where T : class
        {
            prevVal = Interlocked.CompareExchange(ref val, @then, @if);
            return prevVal == @if;
        }

        #endregion

        #region bool Operations

        ///<summary>Bitwise ANDs two 32-bit integers and replaces the first integer with the ANDed value, as an atomic operation.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the first value to be ANDed. The bitwise AND of the two values is stored in <paramref name="target"/>.</param>
        ///<param name="with">The value to AND with <paramref name="target"/>.</param>
        public static int And(ref int target, int with)
        {
            int i, j = target;

            do
            {
                i = j;
                j = Interlocked.CompareExchange(ref target, i & with, i);
            } while (i != j);

            return j;
        }

        ///<summary>Bitwise ORs two 32-bit integers and replaces the first integer with the ORed value, as an atomic operation.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the first value to be ORed. The bitwise OR of the two values is stored in <paramref name="target"/>.</param>
        ///<param name="with">The value to OR with <paramref name="target"/>.</param>
        public static int Or(ref int target, int with)
        {
            int i, j = target;

            do
            {
                i = j;
                j = Interlocked.CompareExchange(ref target, i | with, i);
            } while (i != j);

            return j;
        }

        ///<summary>Bitwise XORs two 32-bit integers and replaces the first integer with the XORed value, as an atomic operation.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the first value to be XORed. The bitwise XOR of the two values is stored in <paramref name="target"/>.</param>
        ///<param name="with">The value to XOR with <paramref name="target"/>.</param>
        public static int Xor(ref int target, int with)
        {
            int i, j = target;

            do
            {
                i = j;
                j = Interlocked.CompareExchange(ref target, i ^ with, i);
            } while (i != j);

            return j;
        }

        #endregion

        #region Masked Operations

        ///<summary>Bitwise ANDs two 32-bit integers with a mask replacing the first integer with the ANDed value, as an atomic operation.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the first value to be ANDed. The bitwise AND of the two values is stored in <paramref name="target"/>.</param>
        ///<param name="with">The value to AND with <paramref name="target"/>.</param>
        ///<param name="mask">The value to AND with <paramref name="target"/> prior to ANDing with <paramref name="with"/>.</param>
        public static int MaskedAnd(ref int target, int with, int mask)
        {
            int i, j = target;

            do
            {
                i = j & mask;  // Mask off the bits we're not interested in
                j = Interlocked.CompareExchange(ref target, i & with, i);
            } while (i != j);

            return j;
        }

        ///<summary>Bitwise ORs two 32-bit integers with a mask replacing the first integer with the ORed value, as an atomic operation.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the first value to be ORed. The bitwise OR of the two values is stored in <paramref name="target"/>.</param>
        ///<param name="with">The value to OR with <paramref name="target"/>.</param>
        ///<param name="mask">The value to AND with <paramref name="target"/> prior to ORing with <paramref name="with"/>.</param>
        public static int MaskedOr(ref int target, int with, int mask)
        {
            int i, j = target;

            do
            {
                i = j & mask;  // Mask off the bits we're not interested in
                j = Interlocked.CompareExchange(ref target, i | with, i);
            } while (i != j);

            return j;
        }

        ///<summary>Bitwise XORs two 32-bit integers with a mask replacing the first integer with the XORed value, as an atomic operation.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the first value to be XORed. The bitwise XOR of the two values is stored in <paramref name="target"/>.</param>
        ///<param name="with">The value to XOR with <paramref name="target"/>.</param>
        ///<param name="mask">The value to AND with <paramref name="target"/> prior to XORing with <paramref name="with"/>.</param>
        public static int MaskedXor(ref int target, int with, int mask)
        {
            int i, j = target;

            do
            {
                i = j & mask;  // Mask off the bits we're not interested in
                j = Interlocked.CompareExchange(ref target, i ^ with, i);
            } while (i != j);

            return j;
        }

        ///<summary>Sets a variable to a specified value as an atomic operation.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the value to be replaced.</param>
        ///<param name="mask">The bits to leave unaffected in <paramref name="target"/> prior to ORing with <paramref name="value"/>.</param>
        ///<param name="value">The value to reaplce <paramref name="target"/> with.</param>
        public static int MaskedExchange(ref int target, int mask, int value)
        {
            int i, j = target;

            do
            {
                i = j;
                j = Interlocked.CompareExchange(ref target, (i & ~mask) | value, j);
            } while (i != j);

            return j;
        }

        #endregion

        #region Bit Operations

        ///<summary>Turns a bit on and returns whether or not it was on.</summary>
        ///<return>Returns whether the bit was on prior to calling this method.</return>
        ///<param name="target">A variable containing the value that is to have a bit turned on.</param>
        ///<param name="bitNum">The bit (0-31) in <paramref name="target"/> that should be turned on.</param>
        public static bool BitTestAndSet(ref int target, int bitNum)
        {
            int tBit = unchecked((int)(1u << bitNum));
            // Turn the bit on and return if it was on
            return (Or(ref target, tBit) & tBit) != 0;
        }

        ///<summary>Turns a bit off and returns whether or not it was on.</summary>
        ///<return>Returns whether the bit was on prior to calling this method.</return>
        ///<param name="target">A variable containing the value that is to have a bit turned off.</param>
        ///<param name="bitNum">The bit (0-31) in <paramref name="target"/> that should be turned off.</param>
        public static bool BitTestAndReset(ref int target, int bitNum)
        {
            int tBit = unchecked((int)(1u << bitNum));
            // Turn the bit off and return if it was on
            return (And(ref target, ~tBit) & tBit) != 0;
        }

        ///<summary>Flips an on bit off or and off bit on.</summary>
        ///<return>Returns whether the bit was on prior to calling this method.</return>
        ///<param name="target">A variable containing the value that is to have a bit flipped.</param>
        ///<param name="bitNum">The bit (0-31) in <paramref name="target"/> that should be flipped.</param>
        public static bool BitTestAndCompliment(ref int target, int bitNum)
        {
            int tBit = unchecked((int)(1u << bitNum));
            // Toggle the bit and return if it was on
            return (Xor(ref target, tBit) & tBit) != 0;
        }

        #endregion

        ///<summary>Adds two integers and replaces the first integer with the sum, as an atomic operation.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the value to be replaced.</param>
        ///<param name="value">The value to add to <paramref name="target"/>.</param>
        ///<param name="mask">The bits in <paramref name="target"/> that should not be affected by adding.</param>
        public static int MaskedAdd(ref int target, int value, int mask)
        {
            int i, j = target;

            do
            {
                i = j & mask;  // Mask off the bits we're not interested in
                j = Interlocked.CompareExchange(ref target, i + value, i);
            } while (i != j);

            return j;
        }

        #region Min and Max Operations

        ///<summary>Increases a value to a new value if the new value is larger.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the value that might be increased to a new maximum.</param>
        ///<param name="val">The value that if larger than <paramref name="target"/> will be placed in <paramref name="target"/>.</param>
        public static int Max(ref int target, int val)
        {
            int i, j = target;

            do
            {
                i = j;
                j = Interlocked.CompareExchange(ref target, Math.Max(i, val), i);
            } while (i != j);

            return j;
        }

        ///<summary>Decreases a value to a new value if the new value is smaller.</summary>
        ///<return>Returns the previous value of <paramref name="target"/>.</return>
        ///<param name="target">A variable containing the value that might be decreased to a new minimum.</param>
        ///<param name="val">The value that if smaller than <paramref name="target"/> will be placed in <paramref name="target"/>.</param>
        public static int Min(ref int target, int val)
        {
            int i, j = target;

            do
            {
                i = j;
                j = Interlocked.CompareExchange(ref target, Math.Min(i, val), i);
            } while (i != j);

            return j;
        }

        public static bool CompareAndExchange(ref int value,
            int ifThisEqualsToValue, int thenExchangeValueWithThis)
        {
            return Interlocked.CompareExchange(ref value,
                thenExchangeValueWithThis, ifThisEqualsToValue) == ifThisEqualsToValue;
        }

        public static bool CompareAndExchange(ref int value,
            int ifThisEqualsToValue, int thenExchangeValueWithThis, out int originalValue)
        {
            originalValue = Interlocked.CompareExchange(
                ref value, thenExchangeValueWithThis, ifThisEqualsToValue);
            return originalValue == ifThisEqualsToValue;
        }

        #endregion
    }
}
