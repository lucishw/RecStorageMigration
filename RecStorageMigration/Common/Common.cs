using System;

namespace Common
{
    class Common
    {
        /// <summary>폴더 이름에서 '\'를 제외한 폴더 이름으로 변환합니다.</summary>
        /// <param name="folderName">폴더 이름</param>
        /// <returns>'\'를 제외한 폴더 이름</returns>
        public String FolderNameCheck(String folderName)
        {
            if(folderName.Substring(folderName.Length - 1) == @"\")
            {
                folderName = folderName.Substring(0,folderName.Length - 1);
                return folderName;
            }
            else if (folderName.Substring(folderName.Length - 2) == @"\\")
            {
                folderName = folderName.Substring(0, folderName.Length - 2);
                return folderName;
            }
            else
            {
                return folderName;
            }
        }
    }
}
