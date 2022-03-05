import { request } from 'umi';
import type { ApplicationListItemDto, ApplicationSearchDto } from './data.d';

/**
 * get application list
 * @param params application search params data exchange object
 * @returns application list item data exchange object
 */
export async function getApplications(
  params: ApplicationSearchDto,
): Promise<{ totalCount: number; items: ApplicationListItemDto[] }> {
  return request('/api/v1/applications', {
    params,
  });
}
