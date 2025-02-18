export function tagMaker(tagList: string): string[] {
  if (tagList.trim().length === 0) {
    return [];
  }

  let tagArr = tagList.toLowerCase().split(' ');
  tagArr = tagArr.filter((item, index) => tagArr.indexOf(item) === index);
  return tagArr;
}
