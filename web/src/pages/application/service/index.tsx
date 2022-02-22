import type { FC } from 'react';
import React, { useState } from 'react';
import { DownOutlined, FilterOutlined, PlusOutlined } from '@ant-design/icons';
import { Avatar, Button, Card, Dropdown, Input, List, Menu, Modal, Progress, Radio } from 'antd';

import { PageContainer } from '@ant-design/pro-layout';
import { useRequest, history } from 'umi';
import moment from 'moment';
import { addFakeList, queryFakeList, removeFakeList, updateFakeList } from './service';
import type { BasicListItemDataType } from './data.d';
import styles from './style.less';
import { LightFilter, ProFormSelect } from '@ant-design/pro-form';

const RadioButton = Radio.Button;
const RadioGroup = Radio.Group;
const { Search } = Input;

const content = (
  <div className={styles.pageHeaderContent}>
    <p>
      这里的服务区别于 Kubernetes 中的{' '}
      <a href="https://kubernetes.io/docs/concepts/services-networking/service/" target="black">
        Service
      </a>{' '}
      的概念。你的一个应用中的 Web
      页面是一个服务，一个接口是一个服务，一个同步的定时任务是一个服务，它是 Kubernetes 中{' '}
      <a href="https://kubernetes.io/docs/concepts/workloads/" target="black">
        Workload
      </a>{' '}
      结合{' '}
      <a href="https://kubernetes.io/docs/concepts/services-networking/service/" target="black">
        Service
      </a>
      、
      <a href="https://kubernetes.io/docs/concepts/services-networking/ingress/" target="black">
        Ingress
      </a>
      、
      <a href="https://kubernetes.io/docs/concepts/storage/volumes/" target="black">
        Volume
      </a>
      /
      <a href="https://kubernetes.io/docs/concepts/storage/persistent-volumes/" target="black">
        Persistent Volumes
      </a>
      、
      <a href="https://kubernetes.io/docs/concepts/configuration/configmap/" target="black">
        ConfigMap
      </a>{' '}
      等等概念所形成的聚合体，是一个提供给终端用户所使用 OR 另外的程序调用的服务
    </p>
    <div className={styles.contentLink}>
      <LightFilter
        bordered
        collapseLabel={<FilterOutlined />}
        onFinish={async (values) => console.log(values)}
      >
        <Search className={styles.extraContentSearch} placeholder="请输入" onSearch={() => ({})} />

        <RadioGroup defaultValue="all">
          <RadioButton value="all">全部</RadioButton>
          <RadioButton value="progress">运行中</RadioButton>
          <RadioButton value="waiting">等待中</RadioButton>
        </RadioGroup>
        <ProFormSelect
          name="applicationId"
          label="所属应用"
          valueEnum={{
            1: '11111',
            2: '22222',
            3: '33333',
          }}
          allowClear
        />
        <Button
          type="primary"
          onClick={() => {
            history.push(`/applications/services/edit`);
          }}
        >
          <PlusOutlined />
          新建服务
        </Button>
      </LightFilter>
    </div>
  </div>
);

const ListContent = ({
  data: { owner, createdAt, percent, status },
}: {
  data: BasicListItemDataType;
}) => (
  <div className={styles.listContent}>
    <div className={styles.listContentItem}>
      <span>Owner</span>
      <p>{owner}</p>
    </div>
    <div className={styles.listContentItem}>
      <span>开始时间</span>
      <p>{moment(createdAt).format('YYYY-MM-DD HH:mm')}</p>
    </div>
    <div className={styles.listContentItem}>
      <Progress percent={percent} status={status} strokeWidth={6} style={{ width: 180 }} />
    </div>
  </div>
);

export const Service: FC = () => {
  const [done, setDone] = useState<boolean>(false);
  const [visible, setVisible] = useState<boolean>(false);
  const [current, setCurrent] = useState<Partial<BasicListItemDataType> | undefined>(undefined);

  const {
    data: listData,
    loading,
    mutate,
  } = useRequest(() => {
    return queryFakeList({
      count: 50,
    });
  });
  const { run: postRun } = useRequest(
    (method, params) => {
      if (method === 'remove') {
        return removeFakeList(params);
      }
      if (method === 'update') {
        return updateFakeList(params);
      }
      return addFakeList(params);
    },
    {
      manual: true,
      onSuccess: (result) => {
        mutate(result);
      },
    },
  );

  const list = listData?.list || [];

  const showEditModal = (item: BasicListItemDataType) => {
    setVisible(true);
    setCurrent(item);
  };

  const deleteItem = (id: string) => {
    postRun('remove', { id });
  };

  const editAndDelete = (key: string | number, currentItem: BasicListItemDataType) => {
    if (key === 'edit') showEditModal(currentItem);
    else if (key === 'delete') {
      Modal.confirm({
        title: '删除服务',
        content: '确定删除该任务吗？',
        okText: '确认',
        cancelText: '取消',
        onOk: () => deleteItem(currentItem.id),
      });
    }
  };

  const MoreBtn: React.FC<{
    item: BasicListItemDataType;
  }> = ({ item }) => (
    <Dropdown
      overlay={
        <Menu onClick={({ key }) => editAndDelete(key, item)}>
          <Menu.Item key="download">下载</Menu.Item>
          <Menu.Item key="delete">删除服务</Menu.Item>
        </Menu>
      }
    >
      <a>
        更多 <DownOutlined />
      </a>
    </Dropdown>
  );

  return (
    <div>
      <PageContainer content={content}>
        <div className={styles.standardList}>
          <Card
            className={styles.listCard}
            bordered={false}
            style={{ marginTop: 24 }}
            bodyStyle={{ padding: '0px 32px 40px 0px' }}
          >
            <List
              size="large"
              rowKey="id"
              loading={loading}
              pagination={{
                showSizeChanger: true,
                showQuickJumper: true,
                pageSize: 10,
                total: list.length,
              }}
              dataSource={list}
              renderItem={(item) => (
                <List.Item
                  actions={[
                    <a
                      key="edit"
                      onClick={(e) => {
                        e.preventDefault();
                        showEditModal(item);
                      }}
                    >
                      编辑
                    </a>,
                    <MoreBtn key="more" item={item} />,
                  ]}
                >
                  <List.Item.Meta
                    avatar={<Avatar src={item.logo} shape="square" size="large" />}
                    title={<a href={item.href}>{item.title}</a>}
                    description={item.subDescription}
                  />
                  <ListContent data={item} />
                </List.Item>
              )}
            />
          </Card>
        </div>
      </PageContainer>
    </div>
  );
};

export default Service;
