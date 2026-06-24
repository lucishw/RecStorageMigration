using System;
using System.IO;

namespace Common
{
    class FileManager
    {
        /// <summary>파일 확장자를 제외한 파일 이름으로 변환합니다.</summary>
        /// <param name="fullPathToFile">파일 전체 경로</param>
        /// <returns>파일 확장자를 제외한 파일 이름</returns>
        public String ReturnFileNameWithoutExtension(String fullPathToFile)
        {
            String fileName = new FileInfo(fullPathToFile).Name;
            String fileExtension = new FileInfo(fullPathToFile).Extension;
            return fileName.Replace(fileExtension, "");            
        }
    }
}
