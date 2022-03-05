/**
 * Application search params data exchange object
 */
export type ApplicationSearchDto = {
  applicationName?: string;
  applicationCode?: string;
  stateType?: number;
  creationTime?: date;
  page?: number = 1;
  limit?: number = 16;
};

/**
 * Application list item data exchange object
 */
export type ApplicationListItemDto = {
  id: string;
  applicationName: string;
  applicationCode: string;
  stateType: number;
  description: string;
};

export type LabelItemDataType = {
  id: React.Key;
  key?: string;
  value?: string;
};
