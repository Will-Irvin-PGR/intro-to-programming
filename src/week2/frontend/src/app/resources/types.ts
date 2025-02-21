export type ResourceListItem = {
  id: string;
  title: string;
  description: string;
  link: string;
  linkText: string;
  createdBy: string;
  createdOn: string;
  tags: string[];
  isBeingReviewedForSecurity?: false;
};

// Option 1 for create model
// export type ResourceListItemCreateModel = {
//   title: string;
//   description: string;
//   link: string;
//   linkText: string;
//   tags: string;
// };

// Option 2 w/ TypeScript trick
export type ResourceListItemCreateModel = Omit<
  ResourceListItem,
  'id' | 'createdOn' | 'createdBy' | 'tags'
> & { tags: string };
