import { Space } from 'antd';
import { GithubOutlined } from '@ant-design/icons';
import React from 'react';
import { useModel, SelectLang } from 'umi';
import Avatar from './AvatarDropdown';
import styles from './index.less';

export type SiderTheme = 'light' | 'dark';

const GlobalHeaderRight: React.FC = () => {
  const { initialState } = useModel('@@initialState');

  if (!initialState || !initialState.settings) {
    return null;
  }

  const { navTheme, layout } = initialState.settings;
  let className = styles.right;

  if ((navTheme === 'dark' && layout === 'top') || layout === 'mix') {
    className = `${styles.right}  ${styles.dark}`;
  }
  return (
    <Space className={className}>
      <span
        className={styles.action}
        onClick={() => {
          window.open('https://github.com/danvic712/ingos');
        }}
      >
        <GithubOutlined />
      </span>
      <SelectLang className={styles.action} />
      <Avatar />
    </Space>
  );
};
export default GlobalHeaderRight;
