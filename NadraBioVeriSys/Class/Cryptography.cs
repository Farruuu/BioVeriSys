using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NadraBioVeriSys
{
	public class Cryptography
	{
		AesCryptoServiceProvider aes;
		public Cryptography()
		{
			aes = new AesCryptoServiceProvider();
			aes.BlockSize = 128;
			aes.KeySize = 256;
			aes.IV = Encoding.UTF8.GetBytes("1234567890123456");
			//aes.Key = Encoding.UTF8.GetBytes("S*FTECHCL!N!CC*NNECTCRYPT*GRAPHY");
			aes.Key = Encoding.UTF8.GetBytes("RUD@NADR@B!O*VER!SYSCRYPT*GRAPHY");
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
		}

		//Pass the plain text to get cipher text
		public string Encrypt(string clearText)
		{
			try
			{
				byte[] byteText = Encoding.UTF8.GetBytes(clearText);
				byte[] byteData = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);
				return Convert.ToBase64String(byteData).Replace(" ", "+");
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		//Pass the cipher text to get plain text
		public string Decrypt(string data)
		{
			data = data.Replace(" ", "+");
			try
			{
				byte[] byteData = Convert.FromBase64String(data);
				byte[] byteText = aes.CreateDecryptor().TransformFinalBlock(byteData, 0, byteData.Length);
				return Encoding.UTF8.GetString(byteText);
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		//Pass the file to get encrypted file
		public string EncryptFile(string filepath)
		{
			try
			{
				byte[] byteText = File.ReadAllBytes(filepath);
				using (var stream = new MemoryStream())
				{
					CryptoStream cryptStream = new CryptoStream(stream, aes.CreateEncryptor(), CryptoStreamMode.Write);
					cryptStream.Write(byteText, 0, byteText.Length);
					cryptStream.FlushFinalBlock();
					File.WriteAllBytes(filepath, stream.ToArray());
				}
				return filepath;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		//Pass the file to get decrypted file
		public string DecryptFile(string filepath)
		{
			try
			{
				byte[] byteText = File.ReadAllBytes(filepath);
				using (var stream = new MemoryStream())
				{
					CryptoStream cryptStream = new CryptoStream(stream, aes.CreateDecryptor(), CryptoStreamMode.Write);
					cryptStream.Write(byteText, 0, byteText.Length);
					cryptStream.FlushFinalBlock();
					File.WriteAllBytes(filepath, stream.ToArray());
				}
				string path = Path.GetFileName(filepath);
				return filepath;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public byte[] EncryptByte(byte[] bytesToEncrypt)
		{
			try
			{
				var stream = new MemoryStream();
				CryptoStream cryptStream = new CryptoStream(stream, aes.CreateEncryptor(), CryptoStreamMode.Write);
				cryptStream.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
				cryptStream.FlushFinalBlock();
				return stream.ToArray();
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public byte[] DecryptByte(byte[] bytesToDecrypt)
		{
			try
			{
				var stream = new MemoryStream();
				CryptoStream cryptStream = new CryptoStream(stream, aes.CreateDecryptor(), CryptoStreamMode.Write);
				cryptStream.Write(bytesToDecrypt, 0, bytesToDecrypt.Length);
				cryptStream.FlushFinalBlock();
				return stream.ToArray();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		//public string HashPassword(string password)
		//{
		//    const int WorkFactor = 14;
		//    string HashedPassword = Convert.ToString(BCrypt.Net.BCrypt.HashPassword(password, WorkFactor));
		//    return HashedPassword;
		//    //if (BCrypt.Net.BCrypt.Verify(password, passwordFromLocalDB) == true)
		//}
		//public bool VerifyHashPassword(string password, string hashPassword)
		//{
		//    return BCrypt.Net.BCrypt.Verify(password, hashPassword);
		//} 
	}
}
