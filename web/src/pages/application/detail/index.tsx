import { PageContainer } from '@ant-design/pro-layout';
import { Button, Descriptions, Statistic, Tag } from 'antd';
import { useParams } from 'umi';

const Detail = () => {
  const { appName } = useParams();

  const content = (column = 2) => (
    <Descriptions size="small" column={column}>
      <Descriptions.Item label="Created">Lili Qu</Descriptions.Item>
      <Descriptions.Item label="Association">
        <a>421421</a>
      </Descriptions.Item>
      <Descriptions.Item label="Creation Time">2017-01-10</Descriptions.Item>
      <Descriptions.Item label="Effective Time">2017-10-10</Descriptions.Item>
      <Descriptions.Item label="Remarks">
        Gonghu Road, Xihu District, Hangzhou, Zhejiang, China
      </Descriptions.Item>
    </Descriptions>
  );

  const extraContent = (
    <div
      style={{
        display: 'flex',
        width: 'max-content',
        justifyContent: 'flex-end',
      }}
    >
      <Statistic
        title="Status"
        value="Pending"
        style={{
          marginRight: 32,
        }}
      />
      <Statistic title="Price" prefix="$" value={568.08} />
    </div>
  );

  return (
    <PageContainer
      title={
        <a href="javascript:void(0)" onClick={() => window.history.back()}>
          {appName}
        </a>
      }
      onBack={() => window.history.back()}
      breadcrumbRender={false}
      extra={[
        <Button key="3">Operation</Button>,
        <Button key="2">Operation</Button>,
        <Button key="1" type="primary">
          Primary
        </Button>,
      ]}
      tags={<Tag color="blue">Running</Tag>}
      content={content}
      extraContent={extraContent}
    />
  );
};

export default Detail;
