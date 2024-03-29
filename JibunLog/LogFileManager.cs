﻿using System;
using System.IO;

namespace JibunLog
{
    /// <summary>
    /// ログアクセスクラス
    /// </summary>
    class LogFileManager
    {
        /// <summary>ログフォルダ名</summary>
        private const string LOG_FOLDER_NAME = "logs";

        /// <summary>行区切り</summary>
        public const string LINE_SEPARATOR = "\r\n";

        /// <summary>
        /// ログフォルダのパスを取得します。
        /// フォルダが存在しない場合は作成します。
        /// </summary>
        /// <returns>カレントフォルダのパス</returns>
        public static string GetLogFolder()
        {
            return GetLogFolder(null);
        }

        /// <summary>
        /// ログフォルダのパスを取得します。
        /// フォルダが存在しない場合は作成します。
        /// </summary>
        /// <returns>カレントフォルダのパス</returns>
        public static string GetLogFolder(string subFolderName)
        {
            string folderPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + LOG_FOLDER_NAME;
            if (!string.IsNullOrEmpty(subFolderName))
            {
                folderPath += Path.DirectorySeparatorChar + subFolderName;
            }

            if (File.Exists(folderPath))
            {
                folderPath = null;
            }
            else if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch (Exception)
                {
                    folderPath = null;
                }
            }

            return folderPath;
        }

        /// <summary>
        /// ログ出力パスを取得します。
        /// </summary>
        /// <returns>ログ出力パス</returns>
        public static string GetLogFilePath()
        {
            string folderPath = GetLogFolder(DateTime.Today.ToString("yyyy"));
            if (folderPath == null)
            {
                return null;
            }
            else
            {
                return string.Format("{0}\\{1}.txt", folderPath, DateTime.Today.ToString("yyyyMM"));
            }
        }

        /// <summary>
        /// ログを書き込みます。
        /// </summary>
        /// <param name="text">ログ文字列</param>
        /// <returns>処理結果</returns>
        public static void Write(string text)
        {
            Write(GetLogFilePath(), text);
        }

        /// <summary>
        /// ログを書き込みます。
        /// </summary>
        /// <param name="filePath">ログファイルパス</param>
        /// <param name="text">ログ文字列</param>
        /// <returns>処理結果</returns>
        public static void Write(string filePath, string text)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.Write(text);
            }
        }

        /// <summary>
        /// 書き込む内容を生成します。
        /// </summary>
        /// <param name="text">入力文章</param>
        /// <returns>書き込む内容</returns>
        public static string GetLogSentence(string text)
        {
            return GetHeader() + LINE_SEPARATOR + text + LINE_SEPARATOR + LINE_SEPARATOR;
        }

        /// <summary>
        /// ヘッダ文字列を取得します。
        /// </summary>
        /// <returns>ヘッダ文字列</returns>
        private static string GetHeader()
        {
            return string.Format("[{0}] ", GetDateTimeString());
        }

        /// <summary>
        /// 日時文字列を取得します。
        /// </summary>
        /// <returns></returns>
        private static string GetDateTimeString()
        {
            return DateTime.Now.ToString("MM/dd HH:mm:ss");
        }

        /// <summary>
        /// 日付文字列を取得します。
        /// </summary>
        /// <returns></returns>
        public static string GetDateString()
        {
            return DateTime.Now.ToString("MM/dd");
        }

        /// <summary>
        /// ログを読み込みます。
        /// </summary>
        /// <returns></returns>
        public static string Read()
        {
            return Read(GetLogFilePath());
        }

        /// <summary>
        /// ログを読み込みます。
        /// </summary>
        /// <param name="filePath">ログファイルパス</param>
        /// <returns></returns>
        public static string Read(string filePath)
        {
            string result = null;

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }

        /// <summary>
        /// 引用符付きテキストを作る
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string MakeQuotedString(string text)
        {
            var lines = text.Replace("\r", "").Split('\n');
            for (var i = 0; i < lines.Length; i++)
            {
                lines[i] = "> " + lines[i];
            }
            return string.Join("\r\n", lines);
        }
    }
}
