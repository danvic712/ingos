import type {
  BasicLayoutProps,
  MenuDataItem,
  Settings as LayoutSettings,
} from '@ant-design/pro-layout';
import { PageLoading } from '@ant-design/pro-layout';
import { history, Link } from 'umi';
import RightContent from '@/components/RightContent';
import Footer from '@/components/Footer';
import { currentUser as queryCurrentUser } from './services/ant-design-pro/api';
import { LinkOutlined } from '@ant-design/icons';
import defaultSettings from '../config/defaultSettings';
import appMenu from '../config/menu';

import { menuIcon } from './utils/utils';

const isDev = process.env.NODE_ENV === 'development';
const loginPath = '/login';

/** 获取用户信息比较慢的时候会展示一个 loading */
export const initialStateConfig = {
  loading: <PageLoading />,
};

/**
 * @see  https://umijs.org/zh-CN/plugins/plugin-initial-state
 * */
export async function getInitialState(): Promise<{
  settings?: Partial<LayoutSettings>;
  currentUser?: API.CurrentUser;
  loading?: boolean;
  fetchUserInfo?: () => Promise<API.CurrentUser | undefined>;
  menu: MenuDataItem[]; // get menu info from menu.ts file
}> {
  const fetchUserInfo = async () => {
    try {
      const msg = await queryCurrentUser();
      return msg.data;
    } catch (error) {
      history.push(loginPath);
    }
    return undefined;
  };
  // 如果是登录页面，不执行
  if (history.location.pathname !== loginPath) {
    const currentUser = await fetchUserInfo();

    return {
      fetchUserInfo,
      currentUser,
      settings: defaultSettings,
      menu: appMenu,
    };
  }
  return {
    fetchUserInfo,
    settings: defaultSettings,
    menu: [],
  };
}

const loopMenuItem = (menus: MenuDataItem[]): MenuDataItem[] =>
  menus.map(({ icon, children, ...item }) => {
    debugger;
    return {
      ...item,
      icon: icon && menuIcon[icon as string],
      children: children && loopMenuItem(children),
    };
  });

// ProLayout 支持的api https://procomponents.ant.design/components/layout
export const layout = ({
  initialState,
}: {
  initialState: { settings?: LayoutSettings; currentUser?: API.CurrentUser; menu: MenuDataItem[] };
}): BasicLayoutProps => {
  return {
    menuDataRender: () => loopMenuItem(initialState.menu),
    rightContentRender: () => <RightContent />,
    disableContentMargin: false,
    waterMarkProps: {},
    footerRender: () => <Footer />,
    onPageChange: () => {
      const { location } = history;
      // redirect to login page, if not logged
      if (!initialState?.currentUser && location.pathname !== loginPath) {
        history.push(loginPath);
      }
    },
    links: isDev
      ? [
          <Link to="/umi/plugin/openapi" target="_blank">
            <LinkOutlined />
            <span>OpenAPI 文档</span>
          </Link>,
        ]
      : [],

    menuHeaderRender: undefined,
  };
};
