export function tagMaker(tagList: string): string[] {
  tagList = tagList.trim();
  if (tagList.length === 0) {
    return [];
  }

  let tagArr = tagList.toLowerCase().split(/ +/);
  tagArr = tagArr.filter((item, index) => tagArr.indexOf(item) === index);
  return tagArr;
}
