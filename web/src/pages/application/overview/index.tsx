import {
  DownloadOutlined,
  EditOutlined,
  EllipsisOutlined,
  InfoCircleOutlined,
  PauseCircleOutlined,
  PlusOutlined,
  ShareAltOutlined,
} from '@ant-design/icons';
import { Button, Card, Dropdown, List, Menu, message, Tooltip, Typography } from 'antd';
import { PageContainer } from '@ant-design/pro-layout';
import { useRequest } from 'umi';
import { queryFakeList } from './service';
import type { CardListItemDataType } from './data';
import styles from './style.less';
import type { ProFormInstance } from '@ant-design/pro-form';
import ProForm, {
  ModalForm,
  ProFormText,
  ProFormDateRangePicker,
  ProFormSelect,
  DrawerForm,
} from '@ant-design/pro-form';
import { useRef } from 'react';

const { Paragraph } = Typography;

const Overview = () => {
  const { data, loading } = useRequest(() => {
    return queryFakeList({
      count: 19,
    });
  });

  const list = data?.list || [];

  const itemMenu = (
    <Menu>
      <Menu.Item>
        <a target="_blank" rel="noopener noreferrer" href="">
          1st menu item
        </a>
      </Menu.Item>
      <Menu.Item>
        <a target="_blank" rel="noopener noreferrer" href="">
          删除
        </a>
      </Menu.Item>
    </Menu>
  );

  const content = (
    <div className={styles.pageHeaderContent}>
      <p>
        当前集群中的所有通过平台部署的应用信息，以应用的维度对集群的资源进行分组，方便针对具体的每个应用进行资源查看管理
      </p>
      <div className={styles.contentLink}>
        <a>
          <img alt="" src="https://gw.alipayobjects.com/zos/rmsportal/MjEImQtenlyueSmVEfUD.svg" />{' '}
          快速开始
        </a>
        <a>
          <img alt="" src="https://gw.alipayobjects.com/zos/rmsportal/NbuDUAuBlIApFuDvWiND.svg" />{' '}
          产品简介
        </a>
        <a>
          <img alt="" src="https://gw.alipayobjects.com/zos/rmsportal/ohOEPSYdDTNnyMbGuyLb.svg" />{' '}
          产品文档
        </a>
      </div>
    </div>
  );

  const extraContent = (
    <div className={styles.extraImg}>
      <img
        alt="这是一个标题"
        src="https://gw.alipayobjects.com/zos/rmsportal/RzwpdLnhmvDJToTdfDPe.png"
      />
    </div>
  );
  const nullData: Partial<CardListItemDataType> = {};

  const formRef = useRef<ProFormInstance>();

  return (
    <PageContainer fixedHeader content={content} extraContent={extraContent}>
      <div className={styles.cardList}>
        <List<Partial<CardListItemDataType>>
          rowKey="id"
          loading={loading}
          grid={{
            gutter: 16,
            xs: 1,
            sm: 2,
            md: 3,
            lg: 3,
            xl: 4,
            xxl: 4,
          }}
          pagination={{
            defaultPageSize: 16,
            showSizeChanger: true,
            pageSizeOptions: ['16', '24', '48', '96'],
          }}
          dataSource={[nullData, ...list]}
          renderItem={(item) => {
            if (item && item.id) {
              return (
                <List.Item key={item.id}>
                  <Card
                    hoverable
                    className={styles.card}
                    actions={[
                      <Tooltip key="info" title="详情">
                        <InfoCircleOutlined />
                      </Tooltip>,
                      <Tooltip key="pause" title="暂停">
                        <PauseCircleOutlined />
                      </Tooltip>,
                      <Dropdown key="ellipsis" overlay={itemMenu}>
                        <EllipsisOutlined />
                      </Dropdown>,
                    ]}
                  >
                    <Card.Meta
                      avatar={<img alt="" className={styles.cardAvatar} src={item.avatar} />}
                      title={<a>{item.title}</a>}
                      description={
                        <Paragraph className={styles.item} ellipsis={{ rows: 3 }}>
                          {item.description}
                        </Paragraph>
                      }
                    />
                  </Card>
                </List.Item>
              );
            }
            return (
              <List.Item>
                <DrawerForm<{
                  name: string;
                  company: string;
                }>
                  title="新建应用"
                  formRef={formRef}
                  width={378}
                  trigger={
                    <Button type="dashed" className={styles.newButton}>
                      <PlusOutlined /> 新增应用
                    </Button>
                  }
                  autoFocusFirstInput
                  drawerProps={{
                    forceRender: true,
                    destroyOnClose: true,
                  }}
                  onFinish={async (values) => {
                    console.log(values.name);
                    message.success('提交成功');
                    // 不返回不会关闭弹框
                    return true;
                  }}
                >
                  <ProForm.Group>
                    <ProFormText
                      name="name"
                      width="md"
                      label="签约客户名称"
                      tooltip="最长为 24 位"
                      placeholder="请输入名称"
                    />
                    <ProFormText
                      width="md"
                      name="company"
                      label="我方公司名称"
                      placeholder="请输入名称"
                    />
                  </ProForm.Group>
                  <ProForm.Group>
                    <ProFormText
                      width="md"
                      name="contract"
                      label="合同名称"
                      placeholder="请输入名称"
                    />
                  </ProForm.Group>
                  <ProFormText name="project" label="项目名称" initialValue="xxxx项目" />
                </DrawerForm>
              </List.Item>
            );
          }}
        />
      </div>
    </PageContainer>
  );
};

export default Overview;
